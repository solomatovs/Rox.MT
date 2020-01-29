using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.Extensions.Logging;

namespace rox.mt4.rest
{
    using rox.mt4.api;
    public static class ClaimTypeOption
    {
        public static string MT4Login { get; } = "mt4_login";
        public static string MT4Server { get; } = "mt4_server";
    }

    public class MT4TokentOption
    {
        public string token { get; set; }
        public Int32 login { get; set; }
        public string password { get; set; }
        public string server { get; set; }
        public MT4ConnectOption GetMT4ConnectOption()
        {
            return new MT4ConnectOption
            {
                login = login,
                password = password,
                server = server,
            };
        }
    }

    public class TokenOption
    {
        public string issuer { get; set; } = "rox_auth_server"; // издатель токена
        public string audience { get; set; } = "rox"; // потребитель токена
        public string key { private get; set; } = "mysupersecret_secretkey!123";   // ключ для шифрации
        public int lifetime { get; set; } = 525600; // время жизни токена - 1 минута
        public IList<MT4TokentOption> tokens { get; set; } = new List<MT4TokentOption>();

        public SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(System.Text.Encoding.ASCII.GetBytes(key));
        }
    }

    public interface ITokenManager
    {
        string TokenInRequest(IEnumerable<string> values);
        MT4Manager MT4ManagerInTokerRequest(IEnumerable<string> values);
        bool IsCurrentActiveToken(IEnumerable<string> values);
        void DeactivateCurrent(IEnumerable<string> values);
        bool IsActive(string token);
        void Deactivate(string token);
        string GenerateNewToken(MT4ConnectOption option);
    }
    public class TokenManager : ITokenManager
    {
        private readonly IDictionary<string, MT4Manager> cache = new ConcurrentDictionary<string, MT4Manager>();
        private readonly TokenOption tokenOption;
        private readonly Func<MT4Manager> mt4managerProvider;

        public TokenManager(
                Func<MT4Manager> mt4managerProvider,
                TokenOption tokenOptions
            )
        {
            this.tokenOption = tokenOptions;
            this.mt4managerProvider = mt4managerProvider;

            foreach (var o in tokenOption.tokens)
            {
                try
                {
                    var m = mt4managerProvider.Invoke();
                    m.Communication(o.GetMT4ConnectOption());
                    cache.Add(o.token, m);
                }
                catch (Exception)
                {
                    // logger.LogWarning($"Configuration warning. Jwt: {o.token} not valid. Login: {o.login}, Server: {o.server} authorization exception: {e.Message}");
                }
            }
        }

        public bool IsCurrentActiveToken(IEnumerable<string> values) => IsActive(TokenInRequest(values));

        public void DeactivateCurrent(IEnumerable<string> values) => Deactivate(TokenInRequest(values));

        public bool IsActive(string token) => cache.TryGetValue(token, out MT4Manager v) && v != null;

        public void Deactivate(string token)
        {
            cache.Remove(token);
        }

        public string TokenInRequest(IEnumerable<string> values)
        {
            return values == StringValues.Empty
                ? string.Empty
                : values.Single().Split(" ").Last();
        }

        private ClaimsIdentity GetIdentity(Action<IList<Claim>> claimsAction)
        {
            var claims = new List<Claim>();
            claimsAction.Invoke(claims);
            var claimsIdentity = new ClaimsIdentity(claims, "token", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

            return claimsIdentity;
        }

        public string GenerateNewToken(MT4ConnectOption connect)
        {
            var manager = mt4managerProvider.Invoke();
            manager.Communication(connect);
            var identity = GetIdentity(c =>
            {
                c.Add(new Claim(ClaimTypeOption.MT4Login, manager.LastLogin.ToString()));
                c.Add(new Claim(ClaimTypeOption.MT4Server, manager.LastServer));
            });

            var now = DateTime.UtcNow;
            // создаем JWT-токен
            var jwt = new JwtSecurityToken(
                    issuer: tokenOption.issuer,
                    audience: tokenOption.audience,
                    notBefore: now,
                    claims: identity.Claims,
                    expires: now.Add(TimeSpan.FromMinutes(tokenOption.lifetime)),
                    signingCredentials: new SigningCredentials(tokenOption.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            cache.Add(encodedJwt, manager);

            return encodedJwt;
        }

        public MT4Manager MT4ManagerInTokerRequest(IEnumerable<string> values)
        {
            var identifier = TokenInRequest(values);
            if (string.IsNullOrWhiteSpace(identifier))
                throw new ArgumentNullException($"token {identifier} not found in server");

            if (!cache.ContainsKey(identifier))
                throw new ArgumentNullException($"MT4Manager is not exists with token {identifier}");

            return cache.First(p => p.Key == identifier).Value;
        }
    }

    public class TokenAuthorizationFilter : Attribute, IAuthorizationFilter
    {
        private readonly ITokenManager manager;
        public TokenAuthorizationFilter(ITokenManager manager)
        {
            this.manager = manager;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var values = context.HttpContext.Request.Headers["authorization"];
            if (manager.TokenInRequest(values) != string.Empty && !manager.IsCurrentActiveToken(values))
            {
                context.Result = new ForbidResult();
            }
        }
    }

    public class AgeRequirement : IAuthorizationRequirement
    {
        protected internal int Age { get; set; }

        public AgeRequirement(int age)
        {
            Age = age;
        }
    }

    public class TokenActiveHandler : IAuthorizationHandler
    {
        private readonly ITokenManager manager;
        private readonly IHttpContextAccessor http;
        public TokenActiveHandler(ITokenManager manager, IHttpContextAccessor http)
        {
            this.manager = manager;
            this.http = http;
        }

        Task IAuthorizationHandler.HandleAsync(AuthorizationHandlerContext context)
        {
            var values = http.HttpContext.Request.Headers["authorization"];
            if (!string.IsNullOrWhiteSpace(manager.TokenInRequest(values)) && !manager.IsCurrentActiveToken(values))
            {
                context.Fail();
            }

            return Task.CompletedTask;
        }
    }

    public static class TokenManagerServiceCollectionExtensions
    {
        public static IServiceCollection AddMT4Manager(this IServiceCollection services, IConfiguration configuration)
        {
            MT4NativeOption native = new MT4NativeOption();
            configuration.GetSection("mtmanapi").Bind(native);
            services.AddSingleton<Func<MT4Manager>>(() => new MT4Manager(native));
            return services;
        }
        public static IServiceCollection AddTokenManager(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddOptions();
            services.Configure<TokenOption>(configuration.GetSection("jwt"));
            services.AddSingleton<IDictionary<string, MT4Manager>>(new ConcurrentDictionary<string, MT4Manager>());
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<ITokenManager, TokenManager>();
            //services.AddCors(config =>
            //{
            //    var policy = new CorsPolicy();
            //    policy.Headers.Add("*");
            //    policy.Methods.Add("*");
            //    policy.Origins.Add("*");
            //    policy.SupportsCredentials = true;
            //    config.AddPolicy("policy", policy);
            //});
            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    var tokenOption = new TokenOption(); configuration.GetSection("jwt").Bind(tokenOption);

                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        // укзывает, будет ли валидироваться издатель при валидации токена
                        ValidateIssuer = true,
                        // строка, представляющая издателя
                        ValidIssuer = tokenOption.issuer,

                        // будет ли валидироваться потребитель токена
                        ValidateAudience = true,
                        // установка потребителя токена
                        ValidAudience = tokenOption.audience,
                        // будет ли валидироваться время существования
                        ValidateLifetime = true,

                        // установка ключа безопасности
                        IssuerSigningKey = tokenOption.GetSymmetricSecurityKey(),
                        // валидация ключа безопасности
                        ValidateIssuerSigningKey = true,
                    };
                });

            services.AddTransient<IAuthorizationHandler, TokenActiveHandler>();

            return services;
        }
    }
}
