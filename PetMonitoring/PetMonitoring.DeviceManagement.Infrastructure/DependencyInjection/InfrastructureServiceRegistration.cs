using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PetMonitoring.DeviceManagement.Application.Interfaces;
using PetMonitoring.DeviceManagement.Infrastructure.Persistence;
using PetMonitoring.DeviceManagement.Infrastructure.Repositories;

namespace PetMonitoring.DeviceManagement.Infrastructure.DependencyInjection
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IDeviceRepository, DeviceRepository>();

            services.AddDbContext<DeviceManagementDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DeviceManagementDb"),
                    sql => sql.MigrationsAssembly("PetMonitoring.DeviceManagement.Infrastructure")
                ));

            return services;
        }
    }
}
