using PetMonitoring.Movement.Domain.Enums;

namespace PetMonitoring.Movement.Application.Commands;

public sealed record CreateMovementCommand
(
    Guid PetId,
    Guid DeviceId,
    DateTime CreatedDate,
    int StepCount,
    double DistanceInMeters,
    ActivityLevel ActivityLevel,
    int ActiveMinutes,
    int InactiveMinutes
);
