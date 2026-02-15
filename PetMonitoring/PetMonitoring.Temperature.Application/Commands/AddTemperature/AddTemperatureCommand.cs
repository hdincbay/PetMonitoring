using MediatR;

namespace PetMonitoring.Temperature.Application.Commands.AddTemperature;

public sealed record AddTemperatureCommand
(
    Guid DeviceId,
    decimal CelsiusValue
) : IRequest<Unit>;
