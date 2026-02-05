using FluentValidation;
using Microsoft.EntityFrameworkCore;
using PetMonitoring.Health.Application.Interfaces;
using PetMonitoring.Health.Application.Services;
using PetMonitoring.Health.Infrastructure.Persistence;
using PetMonitoring.Health.Infrastructure.Persistence.Repositories;
using PetMonitoring.Temperature.Application.Interfaces;
using PetMonitoring.Temperature.Application.Validators;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddValidatorsFromAssembly(
    typeof(CreateTemperatureCommandValidator).Assembly
);
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddScoped<ITemperatureService, TemperatureService>();
builder.Services.AddScoped<ITemperatureRepository, TemperatureRepository>();
builder.Services.AddDbContext<TemperatureDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("TemperatureDb"),
        sql =>
        {
            sql.MigrationsAssembly("PetMonitoring.Temperature.Infrastructure");
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
