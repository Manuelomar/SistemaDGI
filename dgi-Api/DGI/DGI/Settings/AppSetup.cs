using DGI.Application;
using DGI.Infrastructure;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;

namespace DGI.API.Settings
{
    public class AppSetup
    {
        public AppSetup(ConfigurationManager configuration)
        {
            Configuration = configuration;
        }
        public ConfigurationManager Configuration { get; set; }
        public void Configure(IWebHostEnvironment env)
        {
            Configuration.AddJsonFile($"appsettings.{env.EnvironmentName}.json",
                optional: false, reloadOnChange: true);
        }
        public void RegisterServices(IServiceCollection services)
        {
            services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
            services.AddInfrastructure(Configuration);
            services.AddApplication();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.EnableAnnotations();
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DGI", Version = "v1" });

            });
            services.AddCors(options =>
            {
                options.AddPolicy("DevPolicy",
                    builder =>
                    {
                        builder
                            .AllowAnyHeader()
                            .AllowAnyMethod()
                            .AllowCredentials();
                        builder.SetIsOriginAllowed(x => true);
                    });
            });
        }

    }
}
