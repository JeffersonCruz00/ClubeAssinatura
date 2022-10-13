using ClubeAss.API.Customer.Base;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace ClubeAss.API.Customer.Configurations
{
    public static class SerilogConfig
    {
        public static IServiceCollection AddServiceSerilogConfig(this IServiceCollection services)
        {
            return services;
        }

        public static IApplicationBuilder AddConfigureSerilogConfig(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSerilogRequestLogging(opts => opts.EnrichDiagnosticContext = LogEnricherExtensions.EnrichFromRequest);

            app.UseMiddleware<RequestSerilLogMiddleware>();
            app.UseMiddleware<ErrorHandlingMiddleware>();

            return app;
        }
    }
}