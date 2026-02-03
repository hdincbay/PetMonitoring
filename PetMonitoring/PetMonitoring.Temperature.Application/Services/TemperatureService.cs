using PetMonitoring.Temperature.Application.Commands;
using PetMonitoring.Temperature.Application.Interfaces;
using PetMonitoring.Temperature.Domain.Entities;

namespace PetMonitoring.Health.Application.Services;

public class TemperatureService
{
    private readonly ITemperatureRepository _repository;

    public TemperatureService(ITemperatureRepository repository)
    {
        _repository = repository;
    }

    public async Task HandleAsync(CreateTemperatureCommand command)
    {
        var record = new TemperatureRecord(
            command.PetId,
            command.DeviceId,
            command.CreatedDate,
            command.CelsiusValue
        );

        await _repository.AddAsync(record);
    }
}
