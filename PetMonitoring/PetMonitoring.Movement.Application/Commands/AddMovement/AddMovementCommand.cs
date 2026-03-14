using MediatR;
using PetMonitoring.Movement.Application.Results;
using PetMonitoring.Movement.Domain.Enums;

namespace PetMonitoring.Movement.Application.Commands.AddMovement;

public sealed record AddMovementCommand
(
    string DeviceSerialNumber,
    int StepCount,
    double DistanceInMeters,
    ActivityLevel ActivityLevel,
    int ActiveMinutes,
    int InactiveMinutes
) : IRequest<MovementOperationResult>;
