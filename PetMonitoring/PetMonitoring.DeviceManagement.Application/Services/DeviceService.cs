using PetMonitoring.DeviceManagement.Application.Commands;
using PetMonitoring.DeviceManagement.Application.Interfaces;
using PetMonitoring.DeviceManagement.Domain.Entities;
using PetMonitoring.Health.Application.Interfaces;

namespace PetMonitoring.Health.Application.Services;

public class DeviceService : IDeviceService
{
    private readonly IDeviceRepository _repository;

    public DeviceService(IDeviceRepository repository)
    {
        _repository = repository;
    }

    public async Task AddAsync(CreateDeviceCommand command)
    {
        var record = new DeviceRecord(
            command.PetId,
            command.BatteryPercentage
        );

        await _repository.AddAsync(record);
    }

    public Task<IEnumerable<DeviceRecord>> GetByPetIdAsync(Guid petId)
    {
        return _repository.GetByPetIdAsync(petId);
    }
}
