using FluentValidation;
using Microsoft.EntityFrameworkCore;
using PetMonitoring.Health.API.Middlewares;
using PetMonitoring.Health.Application.Commands.AddHeartRate;
using PetMonitoring.Health.Application.Interfaces;
using PetMonitoring.Health.Infrastructure.Persistence;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();

builder.Host.UseSerilog();
builder.Services.AddControllers();
builder.Services.AddValidatorsFromAssembly(
    typeof(AddHeartRateCommandValidator).Assembly
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
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(AddHeartRateCommandHandler).Assembly);
});

var app = builder.Build();
// Configure the HTTP request pipeline.
app.UseMiddleware<RequestLoggingMiddleware>();
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
