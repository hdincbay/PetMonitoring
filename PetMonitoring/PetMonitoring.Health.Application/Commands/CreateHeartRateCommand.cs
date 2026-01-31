namespace PetMonitoring.Health.Application.Commands;

public sealed record CreateHeartRateCommand
(
    Guid PetId,
    Guid DeviceId,
    int Bpm,
    DateTime CreatedDate
);
