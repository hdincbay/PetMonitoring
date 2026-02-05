using PetMonitoring.Temperature.Application.Commands;
using PetMonitoring.Temperature.Application.Interfaces;
using PetMonitoring.Temperature.Domain.Entities;

namespace PetMonitoring.Health.Application.Interfaces;

public interface ITemperatureService
{
    public Task AddAsync(CreateTemperatureCommand command);
    public Task<IEnumerable<TemperatureRecord>> GetByPetIdAsync(Guid petId);
}
