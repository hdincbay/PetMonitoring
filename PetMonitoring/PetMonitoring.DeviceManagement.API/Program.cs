using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PetMonitoring.DeviceManagement.API.Middlewares;
using PetMonitoring.DeviceManagement.Application.Commands.AddDeviceCommand;
using PetMonitoring.DeviceManagement.Application.Interfaces;
using PetMonitoring.DeviceManagement.Infrastructure.Persistence;
using PetMonitoring.DeviceManagement.Infrastructure.Persistence.Repositories;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();

builder.Host.UseSerilog();
builder.Services.AddControllers();
builder.Services.AddValidatorsFromAssembly(
    typeof(UpdateDeviceCommandValidator).Assembly
);
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddScoped<IDeviceRepository, DeviceRepository>();
builder.Services.AddDbContext<DeviceManagementDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DeviceManagementDb"),
        sql =>
        {
            sql.MigrationsAssembly("PetMonitoring.DeviceManagement.Infrastructure");
            sql.MigrationsHistoryTable("__EFMigrationsHistory", "Persistence");
        }));

builder.Services.AddMediatR(
    typeof(CreateDeviceCommandHandler).Assembly
);

var app = builder.Build();
// Configure the HTTP request pipeline.
app.UseMiddleware<RequestLoggingMiddleware>();
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
