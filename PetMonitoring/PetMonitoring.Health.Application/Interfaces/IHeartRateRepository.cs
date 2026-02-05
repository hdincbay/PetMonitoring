using PetMonitoring.Health.Domain.Entities;

namespace PetMonitoring.Health.Application.Interfaces;

public interface IHeartRateRepository
{
    Task AddAsync(HeartRateRecord record);
    Task<IEnumerable<HeartRateRecord>> GetByPetIdAsync(Guid petId);
}