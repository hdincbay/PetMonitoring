using PetMonitoring.Movement.Application.Commands;
using PetMonitoring.Movement.Application.Interfaces;
using PetMonitoring.Movement.Domain.Entities;
namespace PetMonitoring.Movement.Application.Interfaces;

public interface IMovementService
{
    public Task AddAsync(CreateMovementCommand command);
    public Task<IEnumerable<MovementRecord>> GetByPetIdAsync(Guid petId);
}
