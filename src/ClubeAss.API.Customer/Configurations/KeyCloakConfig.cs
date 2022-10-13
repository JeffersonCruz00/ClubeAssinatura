using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace ClubeAss.API.Customer.Configurations
{
    public static class KeyCloakConfig
    {

        public static IServiceCollection AddKeyCloakConfig(this IServiceCollection services, IConfiguration configuration)
        {
            var login = configuration.GetSection("Keycloack").GetSection("ServerLogin").Value;
            var schema = configuration.GetSection("Keycloack").GetSection("Schema").Value;

            services.AddAuthentication(cfg =>
            {
                cfg.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                cfg.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }
               )
               .AddJwtBearer(options =>
               {                   
                   options.Authority = $"{ login }/auth/realms/{schema}/protocol/openid-connect/auth";
                   options.Audience = configuration.GetSection("Keycloack").GetSection("ClientId").Value;
                   options.IncludeErrorDetails = true;
                   options.SaveToken = true;
                   options.RequireHttpsMetadata = false;
                   options.TokenValidationParameters = new TokenValidationParameters
                   {
                       ValidateAudience = false,
                       ValidateIssuer = true,
                       ValidIssuer = $"{ login }/auth/realms/{schema}",
                       ValidateLifetime = false
                   };
               });

            services.AddAuthorization();
            return services;
        }
        public static IApplicationBuilder AddConfigureKeyCloakConfig(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseAuthorization();
            app.UseAuthentication();
            return app;

        }
    }
}
