using ClubeAss.Domain.Interface.Repository;
using ClubeAss.Domain.Repository.IBase;
using ClubeAss.Repository.Postegre;
using ClubeAss.Repository.Postegre.Base;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace ClubeAss.API.Customer.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection AddServiceDependencyInjectionConfig(this IServiceCollection services)
        {
            services.AddScoped<DbSession>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            
            return services;
        }

        public static IApplicationBuilder AddConfigureDependencyInjectionConfig(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            return app;
        }
    }
}