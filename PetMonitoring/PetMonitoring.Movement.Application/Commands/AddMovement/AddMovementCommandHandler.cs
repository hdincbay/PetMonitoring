using MediatR;
using PetMonitoring.Movement.Application.Enums;
using PetMonitoring.Movement.Application.Interfaces;
using PetMonitoring.Movement.Application.Results;
using PetMonitoring.Movement.Domain.Entities;
using PetMonitoring.Movement.Domain.Enums;

namespace PetMonitoring.Movement.Application.Commands.AddMovement;

public sealed class AddMovementCommandHandler : IRequestHandler<AddMovementCommand, MovementOperationResult>
{
    private readonly IMovementRepository _repository;

    public AddMovementCommandHandler(IMovementRepository repository)
    {
        _repository = repository;
    }

    public async Task<MovementOperationResult> Handle(AddMovementCommand request, CancellationToken cancellationToken)
    {
        var record = MovementRecord.Create(request.DeviceSerialNumber, request.StepCount, request.DistanceInMeters, request.ActivityLevel, request.ActiveMinutes, request.InactiveMinutes);
        var createResult = await _repository.AddAsync(record, cancellationToken);
        if (createResult == string.Empty)
        {
            return new MovementOperationResult(
                "MovementRecord creation failed",
                RequestStatus.Failed
            );
        }
        return new MovementOperationResult(
            $"MovementRecord with ID {createResult} created successfully",
            RequestStatus.Success
        );
    }
}