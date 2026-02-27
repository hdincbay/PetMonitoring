using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http.Headers;

namespace PetMonitoring.Web.Infrastructure.AppClients
{
    public static class BaseApiClient
    {
        public static IServiceCollection AddClients(this IServiceCollection services, IConfiguration configuration)
        {
            var baseUrl = configuration["ApiGatewayUrl:https"]!;

            services.AddHttpClient<DeviceApiClient>(client =>
            {
                client.BaseAddress = new Uri(baseUrl);
            });
            services.AddHttpClient<AuthApiClient>(client =>
            {
                client.BaseAddress = new Uri(baseUrl);
            });
            return services;
        }
    }
}