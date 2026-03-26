using MediatR;
using PetMonitoring.Movement.Application.Results;
using PetMonitoring.Movement.Domain.Enums;

namespace PetMonitoring.Movement.Application.Commands.AddMovement;

public sealed record AddMovementCommand
(
    string DeviceSerialNumber,
    ActivityLevel ActivityLevel
) : IRequest<MovementOperationResult>;
