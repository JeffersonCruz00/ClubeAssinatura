using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ClubeAss.API.Customer.Configurations
{
    public static class HealthcheckConfig
    {
        public static IServiceCollection AddServiceHealthcheckConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHealthChecks()
                .AddNpgSql(configuration.GetConnectionString("PGConexao"), name: "Postgres", tags: new string[] { "db", "data" });
            services.AddHealthChecksUI().AddInMemoryStorage();

            return services;
        }

        public static IApplicationBuilder AddConfigureHealthcheckConfig(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Gera o endpoint que retornará os dados utilizados no dashboard
            app.UseHealthChecks("/healthchecks-data-ui", new HealthCheckOptions()
            {
                Predicate = _ => true,
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });

            // Ativa o dashboard para a visualização da situação de cada Health Check
            app.UseHealthChecksUI(options =>
            {
                options.UIPath = "/monitor";
            });

            return app;
        }
    }
}