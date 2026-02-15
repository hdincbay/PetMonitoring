using MediatR;
using PetMonitoring.Movement.Domain.Enums;

namespace PetMonitoring.Movement.Application.Commands.AddMovement;

public sealed record AddMovementCommand
(
    Guid DeviceId,
    int StepCount,
    double DistanceInMeters,
    ActivityLevel ActivityLevel,
    int ActiveMinutes,
    int InactiveMinutes
) : IRequest<Unit>;
