using FluentValidation;
using Microsoft.EntityFrameworkCore;
using PetMonitoring.Movement.Application.Commands.AddMovement;
using PetMonitoring.Movement.Application.Interfaces;
using PetMonitoring.Movement.Application.Validators;
using PetMonitoring.Movement.Infrastructure.Persistence;
using PetMonitoring.Movement.Infrastructure.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddValidatorsFromAssembly(
    typeof(AddMovementCommandValidator).Assembly
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
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(AddMovementCommand).Assembly);
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
