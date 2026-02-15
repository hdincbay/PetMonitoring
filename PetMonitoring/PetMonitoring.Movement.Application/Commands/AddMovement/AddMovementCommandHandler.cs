using MediatR;
using PetMonitoring.Movement.Application.Interfaces;
using PetMonitoring.Movement.Domain.Entities;
using PetMonitoring.Movement.Domain.Enums;

namespace PetMonitoring.Movement.Application.Commands.AddMovement;

public sealed class AddMovementCommandHandler : IRequestHandler<AddMovementCommand, Unit>
{
    private readonly IMovementRepository _repository;

    public AddMovementCommandHandler(IMovementRepository repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(AddMovementCommand request, CancellationToken cancellationToken)
    {
        var movementRecord = MovementRecord.Create(request.DeviceId, request.StepCount, request.DistanceInMeters, request.ActivityLevel, request.ActiveMinutes, request.InactiveMinutes);
        await _repository.AddAsync(movementRecord, cancellationToken);
        return Unit.Value;
    }
}