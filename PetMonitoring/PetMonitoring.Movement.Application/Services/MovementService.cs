using PetMonitoring.Movement.Application.Commands;
using PetMonitoring.Movement.Application.Interfaces;
using PetMonitoring.Movement.Domain.Entities;
using PetMonitoring.Movement.Domain.Enums;

namespace PetMonitoring.Health.Application.Services;

public class MovementService
{
    private readonly IMovementRepository _repository;

    public MovementService(IMovementRepository repository)
    {
        _repository = repository;
    }

    public async Task HandleAsync(CreateMovementCommand command)
    {
        var record = new MovementRecord(
            command.PetId,
            command.DeviceId,
            command.StepCount,
            command.DistanceInMeters,
            command.ActivityLevel,
            command.ActiveMinutes,
            command.InactiveMinutes
        );

        await _repository.AddAsync(record);
    }
}
