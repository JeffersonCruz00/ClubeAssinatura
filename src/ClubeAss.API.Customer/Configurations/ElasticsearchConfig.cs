﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nest;
using System;

namespace ClubeAss.API.Customer.Configurations
{
    public static class ElasticsearchConfig
    {
        public static void AddElasticsearchConfig(this IServiceCollection services, IConfiguration configuration)
        {
            var settings = new ConnectionSettings(new Uri(configuration["ElasticsearchSettings:uri"]));

            var defaultIndex = configuration["ElasticsearchSettings:defaultIndex"];

            if (!string.IsNullOrEmpty(defaultIndex))
                settings = settings.DefaultIndex(defaultIndex);

            var basicAuthUser = configuration["ElasticsearchSettings:username"];
            var basicAuthPassword = configuration["ElasticsearchSettings:password"];

            if (!string.IsNullOrEmpty(basicAuthUser) && !string.IsNullOrEmpty(basicAuthPassword))
                settings = settings.BasicAuthentication(basicAuthUser, basicAuthPassword);

            var client = new ElasticClient(settings);

            services.AddSingleton<IElasticClient>(client);
        }
    }
}