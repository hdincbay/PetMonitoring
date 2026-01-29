using PetMonitoring.DeviceManagement.Application.Commands;
using PetMonitoring.DeviceManagement.Application.Interfaces;
using PetMonitoring.DeviceManagement.Domain.Entities;

namespace PetMonitoring.Health.Application.Services;

public class DeviceService
{
    private readonly IDeviceRepository _repository;

    public DeviceService(IDeviceRepository repository)
    {
        _repository = repository;
    }

    public async Task HandleAsync(CreateDeviceCommand command)
    {
        var record = new DeviceRecord(
            command.PetId
        );

        await _repository.AddAsync(record);
    }
}
