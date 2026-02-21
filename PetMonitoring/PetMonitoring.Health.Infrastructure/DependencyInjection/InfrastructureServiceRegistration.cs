using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PetMonitoring.Health.Application.Interfaces;
using PetMonitoring.Health.Infrastructure.Persistence;
using PetMonitoring.Health.Infrastructure.Repositories;

namespace PetMonitoring.Health.Infrastructure.DependencyInjection
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IHeartRateRepository, HeartRateRepository>();
            services.AddDbContext<HealthDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("HealthDb"),
                    sql =>
                    {
                        sql.MigrationsAssembly("PetMonitoring.Health.Infrastructure");
                        sql.MigrationsHistoryTable("__EFMigrationsHistory", "Persistence");
                    }));
            return services;
        }
    }
}
