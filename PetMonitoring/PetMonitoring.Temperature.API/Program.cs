using FluentValidation;
using Microsoft.EntityFrameworkCore;
using PetMonitoring.Temperature.Infrastructure.Persistence;
using PetMonitoring.Temperature.Infrastructure.Persistence.Repositories;
using PetMonitoring.Temperature.Application.Commands.AddTemperature;
using PetMonitoring.Temperature.Application.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddValidatorsFromAssembly(
    typeof(AddTemperatureCommandValidator).Assembly
);
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddScoped<ITemperatureRepository, TemperatureRepository>();
builder.Services.AddDbContext<TemperatureDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("TemperatureDb"),
        sql =>
        {
            sql.MigrationsAssembly("PetMonitoring.Temperature.Infrastructure");
            sql.MigrationsHistoryTable("__EFMigrationsHistory", "Persistence");
        }));
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(AddTemperatureCommand).Assembly);
});
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
