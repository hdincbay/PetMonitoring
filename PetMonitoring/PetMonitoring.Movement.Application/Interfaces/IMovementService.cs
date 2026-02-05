using PetMonitoring.Movement.Application.Commands;
using PetMonitoring.Movement.Application.Interfaces;
using PetMonitoring.Movement.Domain.Entities;
using PetMonitoring.Movement.Domain.Enums;

namespace PetMonitoring.Health.Application.Interfaces;

public interface IMovementService
{
    public Task HandleAsync(CreateMovementCommand command);
}
