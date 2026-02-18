using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PetMonitoring.Auth.Domain;
using PetMonitoring.Auth.Infrastructure.Persistence;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();

builder.Host.UseSerilog();
builder.Services
    .AddIdentity<User, IdentityRole<Guid>>(options =>
    {
        options.User.RequireUniqueEmail = true;
        options.Password.RequiredLength = 6;
        options.Password.RequireDigit = true;
    })
    .AddEntityFrameworkStores<AuthDbContext>()
    .AddDefaultTokenProviders();
builder.Services.AddDbContext<AuthDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("AuthDb"),
        sql =>
        {
            sql.MigrationsAssembly("PetMonitoring.Auth.Infrastructure");
            sql.MigrationsHistoryTable("__EFMigrationsHistory", "Persistence");
        }));
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
