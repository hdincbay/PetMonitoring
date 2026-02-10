using PetMonitoring.Movement.Domain.Entities;

namespace PetMonitoring.Movement.Application.Interfaces;

public interface IMovementRepository
{
    Task AddAsync(MovementRecord record, CancellationToken ct);
    Task<MovementRecord?> GetByDeviceIdAsync(Guid deviceId, CancellationToken cancellationToken);
}
