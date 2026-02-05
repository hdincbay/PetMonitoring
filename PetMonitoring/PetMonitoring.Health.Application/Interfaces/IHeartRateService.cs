using PetMonitoring.Health.Application.Commands;
using PetMonitoring.Health.Application.Interfaces;
using PetMonitoring.Health.Domain.Entities;

namespace PetMonitoring.Health.Application.Interfaces;

public interface IHeartRateService
{
    public Task AddAsync(CreateHeartRateCommand command);
    public Task<IEnumerable<HeartRateRecord>> GetByPetIdAsync(Guid petId);
}
