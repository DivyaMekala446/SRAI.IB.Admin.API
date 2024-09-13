using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace SRAI.IB.Admin.API
{
    /// <summary>
    /// Startup class
    /// </summary>
    public class Startup : IB.API.Startup
    {
        /// <inheritdoc/>
        public Startup(IHostEnvironment env) : base(env)
        {
        }

        /// <inheritdoc/>
        public override void AddLocalEndpoints(IEndpointRouteBuilder routesBuilder)
        {
        }

        /// <inheritdoc/>
        public override string ApiVersion => "v1";

        /// <inheritdoc/>
        public override string ApiName => "Insights Builder Admin API";

        /// <inheritdoc/>
        public override string SwaggerRoutePrefix() => "admin";


        /// <inheritdoc/>
        [ExcludeFromCodeCoverage]
        public override void AddSwaggerDoc(SwaggerGenOptions c)
        {
            c.SwaggerDoc(ApiVersion, new OpenApiInfo
            {
                Version = ApiVersion,
                Description = "Insights Builder Admin API",
                Title = ApiName
            });

            //c.SwaggerDoc("v2", new OpenApiInfo
            //{
            //    Version = "v2",
            //    Description = ApiName,
            //    Title = ApiName
            //});
        }
        /// <inheritdoc/>
        [ExcludeFromCodeCoverage]
        public override void AddSwaggerXMLComments(SwaggerGenOptions c)
        {
            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            c.IncludeXmlComments(xmlPath);
        }

        /// <inheritdoc/>
        [ExcludeFromCodeCoverage]
        public override void AddSwaggerServers(SwaggerGenOptions c)
        {
            c.AddServer(new OpenApiServer { Description = "Local Environment Admin Server API", Url = "https://localhost:7538" });
            //http://localhost:5183
        }

        /// <inheritdoc/>
        [ExcludeFromCodeCoverage]
        public override void ResolveLocalServices(IServiceCollection services)
        {
            services.AddApplicationInsightsTelemetry();
            //services.ResolveAdminCore();
        }
    }
}