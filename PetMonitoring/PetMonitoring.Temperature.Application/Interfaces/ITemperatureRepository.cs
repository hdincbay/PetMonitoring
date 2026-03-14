using PetMonitoring.Temperature.Domain.Entities;

namespace PetMonitoring.Temperature.Application.Interfaces;

public interface ITemperatureRepository
{
    Task<string> AddAsync(TemperatureRecord record, CancellationToken ct);
    Task<TemperatureRecord?> GetByDeviceSerialNumberAsync(string deviceSerialNumber, CancellationToken ct);
}
