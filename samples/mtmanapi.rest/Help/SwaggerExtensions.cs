using System.Linq;
using System.Reflection;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;


namespace rox.mt4.rest
{
    public class SwaggerUIOption
    {
        public string Json { get; set; } = "/swagger/v1/swagger.json";
        public string RoutePrefix { get; set; } = "";
    }
    public class SwaggerOption
    {
        public string Version { get; set; } = "v1";
        public string Title { get; set; } = "MetaTrader 4 Web API";
        public string Name { get; set; } = "Jordan Rudess 🎵";
        public string Email { get; set; } = "contact@email.com";
        public string Description { get; set; } = @"original documentation for MetaTrader 4 Manager API on C++: https://support.metaquotes.net/ru/docs/mt4/api/manager_api. Use /Login method for Authorization";
        public SwaggerUIOption UI { get; set; } = default;
    }
    public static class SwaggerExtensions
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services, IConfiguration configuration)
        {
            var options = new SwaggerOption(); configuration.Bind("swagger", options);
            // add swagger doc for api
            services.AddSwaggerGen(c =>
            {
                var scheme = new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization. To obtain a token, use the /Login. Then enter the token in the \"Value\" field in the format: \"Bearer {token}\"",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" },
                };
                c.AddSecurityDefinition("Bearer", scheme);
                c.AddSecurityRequirement(new OpenApiSecurityRequirement { { scheme, new string[0] } });

                c.SwaggerDoc(options.Version, new OpenApiInfo
                {
                    Title = options.Title,
                    Version = options.Version,
                    Contact = new OpenApiContact
                    {
                        Name = options.Name,
                        Email = options.Email,
                    },
                    Description = options.Description
                });
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
                c.DescribeAllEnumsAsStrings();

                //var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                //var xmlPath = Path.Combine(System.AppContext.BaseDirectory, xmlFile);
                //c.IncludeXmlComments(xmlPath);

                c.MapType<System.DateTime>(() => new OpenApiSchema { Type = "string" });
                c.MapType<IResponseError>(() => new OpenApiSchema { Type = "object" });

                c.OperationFilter<SwagerTagFilter>();
            });
            return services;
        }

        public static IApplicationBuilder UseSwagger(this IApplicationBuilder app, IConfiguration configuration)
        {
            var options = new SwaggerOption(); configuration.Bind("Swagger", options);
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(options.UI.Json, options.Title);
                c.RoutePrefix = options.UI.RoutePrefix;
                //c.DefaultModelExpandDepth(2);
                //c.DefaultModelRendering(ModelRendering.Model);
                //c.DefaultModelsExpandDepth(-1);
                //c.DisplayOperationId();
                //c.DisplayRequestDuration();
                c.DocExpansion(DocExpansion.None);
                //c.EnableDeepLinking();
                c.EnableFilter();
                ////c.MaxDisplayedTags(5);
                c.ShowExtensions();
                c.EnableValidator();
                //c.SupportedSubmitMethods(SubmitMethod.Get, SubmitMethod.Head);
            });
            return app;
        }
    }
}
