using FluentValidation;
using Microsoft.EntityFrameworkCore;
using PetMonitoring.DeviceManagement.Application.Interfaces;
using PetMonitoring.DeviceManagement.Infrastructure.Persistence;
using PetMonitoring.DeviceManagement.Infrastructure.Persistence.Repositories;
using PetMonitoring.Health.Application.Interfaces;
using PetMonitoring.Health.Application.Services;
using PetMonitoring.Health.Application.Validators;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddValidatorsFromAssembly(
    typeof(CreateDeviceCommandValidator).Assembly
);
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddScoped<IDeviceService, DeviceService>();
builder.Services.AddScoped<IDeviceRepository, DeviceRepository>();
builder.Services.AddDbContext<DeviceManagementDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DeviceManagementDb"),
        sql =>
        {
            sql.MigrationsAssembly("PetMonitoring.DeviceManagement.Infrastructure");
            sql.MigrationsHistoryTable("__EFMigrationsHistory", "Persistence");
        }));

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
