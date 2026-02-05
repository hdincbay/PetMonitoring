using PetMonitoring.Health.Application.Commands;
using PetMonitoring.Health.Application.Interfaces;
using PetMonitoring.Health.Domain.Entities;

namespace PetMonitoring.Health.Application.Services;

public class HeartRateService : IHeartRateService
{
    private readonly IHeartRateRepository _repository;

    public HeartRateService(IHeartRateRepository repository)
    {
        _repository = repository;
    }

    public async Task HandleAsync(CreateHeartRateCommand command)
    {
        var record = new HeartRateRecord(
            command.PetId,
            command.DeviceId,
            command.Bpm,
            command.CreatedDate
        );

        await _repository.AddAsync(record);
    }
}
