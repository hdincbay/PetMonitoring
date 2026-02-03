namespace PetMonitoring.DeviceManagement.Application.Commands;

public sealed record CreateDeviceCommand
(
    Guid PetId,
    DateTime CreatedDate,
    int BatteryPercentage
);
