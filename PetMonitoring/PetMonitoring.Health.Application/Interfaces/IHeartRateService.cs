using PetMonitoring.Health.Application.Commands;
using PetMonitoring.Health.Application.Interfaces;
using PetMonitoring.Health.Domain.Entities;

namespace PetMonitoring.Health.Application.Interfaces;

public interface IHeartRateService
{
    public Task HandleAsync(CreateHeartRateCommand command);
}
