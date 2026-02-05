using PetMonitoring.DeviceManagement.Application.Commands;
using PetMonitoring.DeviceManagement.Application.Interfaces;
using PetMonitoring.DeviceManagement.Domain.Entities;

namespace PetMonitoring.Health.Application.Interfaces;

public interface IDeviceService
{
    public Task HandleAsync(CreateDeviceCommand command);
}
