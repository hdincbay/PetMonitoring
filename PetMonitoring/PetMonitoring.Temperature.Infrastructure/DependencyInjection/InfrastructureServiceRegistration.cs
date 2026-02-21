using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PetMonitoring.Temperature.Application.Interfaces;
using PetMonitoring.Temperature.Infrastructure.Persistence;
using PetMonitoring.Temperature.Infrastructure.Repositories;

namespace PetMonitoring.Movement.Infrastructure.DependencyInjection
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ITemperatureRepository, TemperatureRepository>();
            services.AddDbContext<TemperatureDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("TemperatureDb"),
                    sql =>
                    {
                        sql.MigrationsAssembly("PetMonitoring.Temperature.Infrastructure");
                        sql.MigrationsHistoryTable("__EFMigrationsHistory", "Persistence");
                    }));
            return services;
        }
    }
}
