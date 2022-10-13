using ClubeAss.API.Customer.Configurations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ClubeAss.API.Customer
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
            services.AddServiceAppConfig();
            services.AddServiceDependencyInjectionConfig();
            services.AddServiceHealthcheckConfig(Configuration);
            services.AddServiceSwaggerConfig(Configuration);
            services.AddServiceAutoMapperConfig();
            services.AddElasticsearchConfig(Configuration);
            services.AddMediatrConfig();
            //services.AddKeyCloakConfig(Configuration);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.AddConfigureAppConfig(env);
            app.AddConfigureSerilogConfig(env);
            app.AddConfigureHealthcheckConfig(env);
            app.AddConfigureSwaggerConfig(env);
            //app.AddConfigureKeyCloakConfig(env);
        }
    }
}