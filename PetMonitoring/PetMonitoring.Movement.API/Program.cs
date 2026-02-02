using FluentValidation;
using Microsoft.EntityFrameworkCore;
using PetMonitoring.Health.Application.Validators;
using PetMonitoring.Health.Infrastructure.Persistence;
using PetMonitoring.Health.Infrastructure.Persistence.Repositories;
using PetMonitoring.Movement.Application.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddValidatorsFromAssembly(
    typeof(CreateMovementCommandValidator).Assembly
);
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddScoped<IMovementRepository, MovementRepository>();
builder.Services.AddDbContext<MovementDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("MovementDb"),
        sql =>
        {
            sql.MigrationsAssembly("PetMonitoring.Movement.Infrastructure");
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
