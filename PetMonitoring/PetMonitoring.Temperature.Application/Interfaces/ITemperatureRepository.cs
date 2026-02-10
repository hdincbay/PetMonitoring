using PetMonitoring.Temperature.Domain.Entities;

namespace PetMonitoring.Temperature.Application.Interfaces;

public interface ITemperatureRepository
{
    Task AddAsync(TemperatureRecord record, CancellationToken ct);
    Task<TemperatureRecord?> GetByDeviceIdAsync(Guid deviceId, CancellationToken ct);
}
