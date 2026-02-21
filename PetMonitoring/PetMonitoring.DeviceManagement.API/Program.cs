using FluentValidation;
using MediatR;
using PetMonitoring.DeviceManagement.API.Middlewares;
using PetMonitoring.DeviceManagement.Application.Commands.CreateDeviceCommand;
using Serilog;
using PetMonitoring.DeviceManagement.Infrastructure.DependencyInjection;

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
builder.Services.AddInfrastructureServices(builder.Configuration);
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
