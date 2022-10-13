using AutoMapper;
using ClubeAss.Domain.Commands;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace ClubeAss.API.Customer.Configurations
{
    public static class AutoMapperConfig
    {
        public static IServiceCollection AddServiceAutoMapperConfig(this IServiceCollection services)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CustomerResponse, Domain.Customer>();
                cfg.CreateMap<Domain.Customer, CustomerResponse>();

                cfg.CreateMap<CustomerAddRequest, Domain.Customer>();
                cfg.CreateMap<Domain.Customer, CustomerAddRequest>();

                cfg.CreateMap<CustomerUpdateRequest, Domain.Customer>();
                cfg.CreateMap<Domain.Customer, CustomerUpdateRequest>();

            });

            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);

            return services;
        }

        public static IApplicationBuilder AddConfigureAutoMapperConfig(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            return app;
        }
    }
}