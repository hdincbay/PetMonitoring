using PetMonitoring.Health.Domain.Entities;

namespace PetMonitoring.Health.Application.Interfaces;

public interface IHeartRateRepository
{
    Task AddAsync(HeartRateRecord record, CancellationToken cancellationToken);
    Task<HeartRateRecord?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<HeartRateRecord?> GetByDeviceIdAsync(Guid deviceId, CancellationToken cancellationToken);
}
