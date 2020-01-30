using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace rox.mt4.rest
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHsts(options =>
            {
                options.Preload = true;
                options.IncludeSubDomains = true;
                options.MaxAge = System.TimeSpan.FromDays(600);
            });
            services.AddMT4Manager(Configuration.GetSection("mtmanapi"));
            services.AddTokenManager(Configuration.GetSection("jwt"));
            services.AddMvc(option => option.EnableEndpointRouting = false)
                .AddNewtonsoftJson(o =>
                {
                    o.SerializerSettings.ContractResolver = new ContractResolver();
                    o.SerializerSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
                    o.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss.FFFFFFFK";
                })
                .AddMT4ModelBinding()
                .AddApiFilters()
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services.AddSwagger(Configuration);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                app.UseHsts();
            app.UseHttpsRedirection();
            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod()
            );
            app.UseAuthentication();
            app.UseWebSockets();
            app.UseMvc();
            app.UseSwagger(Configuration);
        }
    }
}
