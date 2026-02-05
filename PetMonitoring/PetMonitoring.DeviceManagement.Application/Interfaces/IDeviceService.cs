using PetMonitoring.DeviceManagement.Application.Commands;
using PetMonitoring.DeviceManagement.Application.Interfaces;
using PetMonitoring.DeviceManagement.Domain.Entities;

namespace PetMonitoring.Health.Application.Interfaces;
public interface IDeviceService
{
    public Task AddAsync(CreateDeviceCommand command);
    public Task<IEnumerable<DeviceRecord>> GetByPetIdAsync(Guid petId);
}
