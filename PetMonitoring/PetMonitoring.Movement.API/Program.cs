using FluentValidation;
using MediatR;
using PetMonitoring.Movement.API.Middlewares;
using PetMonitoring.Movement.Application.Commands.AddMovement;
using PetMonitoring.Movement.Application.Validators;
using Serilog;
using PetMonitoring.Movement.Infrastructure.DependencyInjection;
using PetMonitoring.Movement.Application.Mappings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();
builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddMaps(typeof(MovementMappingProfile).Assembly);
});
builder.Host.UseSerilog();
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddValidatorsFromAssembly(
    typeof(AddMovementCommandValidator).Assembly
);
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddMediatR(
    typeof(AddMovementCommandHandler).Assembly
);
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
