using MediatR;

namespace PetMonitoring.Temperature.Application.Commands.AddTemperature;

public sealed record AddTemperatureCommand
(
    Guid PetId,
    Guid DeviceId,
    decimal CelsiusValue
) : IRequest<Unit>;
