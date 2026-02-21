using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PetMonitoring.Movement.Application.Interfaces;
using PetMonitoring.Movement.Infrastructure.Persistence;
using PetMonitoring.Movement.Infrastructure.Repositories;

namespace PetMonitoring.Movement.Infrastructure.DependencyInjection
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IMovementRepository, MovementRepository>();
            services.AddDbContext<MovementDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("MovementDb"),
                    sql =>
                    {
                        sql.MigrationsAssembly("PetMonitoring.Movement.Infrastructure");
                        sql.MigrationsHistoryTable("__EFMigrationsHistory", "Persistence");
                    }));
            return services;
        }
    }
}
