using PetMonitoring.Movement.Domain.Entities;

namespace PetMonitoring.Movement.Application.Interfaces;

public interface IMovementRepository
{
    Task<string> AddAsync(MovementRecord record, CancellationToken ct);
    Task<MovementRecord?> GetByDeviceSerialNumberAsync(string deviceSerialNumber, CancellationToken cancellationToken);
}
