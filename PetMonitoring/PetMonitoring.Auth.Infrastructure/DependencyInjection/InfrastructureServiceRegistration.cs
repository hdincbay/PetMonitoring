using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PetMonitoring.Auth.Application.Interfaces;
using PetMonitoring.Auth.Domain.Entities;
using PetMonitoring.Auth.Infrastructure.Persistence;
using PetMonitoring.Auth.Infrastructure.Repositories;
using PetMonitoring.Auth.Infrastructure.Security;

namespace PetMonitoring.Auth.Infrastructure.DependencyInjection
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services
             .AddIdentity<User, IdentityRole<Guid>>(options =>
             {
                 options.User.RequireUniqueEmail = true;
                 options.Password.RequiredLength = 6;
                 options.Password.RequireDigit = true;
             })
             .AddEntityFrameworkStores<AuthDbContext>()
             .AddDefaultTokenProviders();
                    services.AddDbContext<AuthDbContext>(options =>
                        options.UseSqlServer(
                            configuration.GetConnectionString("AuthDb"),
                            sql =>
                            {
                                sql.MigrationsAssembly("PetMonitoring.Auth.Infrastructure");
                                sql.MigrationsHistoryTable("__EFMigrationsHistory", "Persistence");
                            }));
            services.Configure<JwtSettings>(
                configuration.GetSection("JwtSettings"));
            services.AddSingleton<ITokenService, JwtTokenService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
