using PetMonitoring.DeviceManagement.Domain.Entities;

namespace PetMonitoring.DeviceManagement.Application.Interfaces;

public interface IDeviceRepository
{
    Task AddAsync(DeviceRecord record);
    Task<IEnumerable<DeviceRecord>> GetByPetIdAsync(Guid petId);
}
