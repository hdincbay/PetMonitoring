using PetMonitoring.Temperature.Domain.Entities;

namespace PetMonitoring.Temperature.Application.Interfaces;

public interface ITemperatureRepository
{
    Task AddAsync(TemperatureRecord record);
    Task<IEnumerable<TemperatureRecord>> GetByPetIdAsync(Guid petId);
}
