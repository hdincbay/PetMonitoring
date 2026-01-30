using FluentValidation;
using Microsoft.EntityFrameworkCore;
using PetMonitoring.Health.Application.Interfaces;
using PetMonitoring.Health.Application.Validators;
using PetMonitoring.Health.Infrastructure.Persistence;
using PetMonitoring.Health.Infrastructure.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddValidatorsFromAssembly(
    typeof(CreateHeartRateCommandValidator).Assembly
);
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddScoped<IHeartRateRepository, HeartRateRepository>();
builder.Services.AddDbContext<HealthDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("HealthDb"),
        sql =>
        {
            sql.MigrationsAssembly("PetMonitoring.Health.Infrastructure");
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
