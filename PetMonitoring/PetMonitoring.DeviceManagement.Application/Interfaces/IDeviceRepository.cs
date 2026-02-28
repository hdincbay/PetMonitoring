using PetMonitoring.DeviceManagement.Domain.Entities;

namespace PetMonitoring.DeviceManagement.Application.Interfaces;

public interface IDeviceRepository 
{
    Task<string?> CreateAsync(DeviceRecord record, CancellationToken ct);
    Task<bool> UpdateAsync(DeviceRecord record, CancellationToken ct);
    Task<IEnumerable<DeviceRecord>?> GetAllAsync(CancellationToken ct);
    Task<DeviceRecord?> GetByDeviceIdAsync(Guid deviceId, CancellationToken ct);
    Task<DeviceRecord?> GetBySerialNumberAsync(string serialNumber, CancellationToken ct);
}
