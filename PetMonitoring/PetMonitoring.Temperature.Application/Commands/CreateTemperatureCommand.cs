namespace PetMonitoring.Temperature.Application.Commands;

public sealed record CreateTemperatureCommand
(
    Guid PetId,
    Guid DeviceId,
    decimal CelsiusValue,
    DateTime CreatedDate
);
