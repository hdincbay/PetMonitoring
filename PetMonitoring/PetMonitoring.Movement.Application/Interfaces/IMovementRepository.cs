using PetMonitoring.Movement.Domain.Entities;

namespace PetMonitoring.Movement.Application.Interfaces;

public interface IMovementRepository
{
    Task AddAsync(MovementRecord record);
    Task<IEnumerable<MovementRecord>> GetByPetIdAsync(Guid petId);
}
