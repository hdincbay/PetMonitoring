using PetMonitoring.DeviceManagement.Domain.Entities;

namespace PetMonitoring.DeviceManagement.Application.Interfaces;

public interface IDeviceRepository
{
    Task AddAsync(DeviceRecord record, CancellationToken ct);
    Task UpdateAsync(DeviceRecord record, CancellationToken ct);
    Task<DeviceRecord?> GetByDeviceIdAsync(Guid petId, CancellationToken ct);
}
