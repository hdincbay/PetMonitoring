using MediatR;
using PetMonitoring.Temperature.Application.Interfaces;
using PetMonitoring.Temperature.Domain.Entities;

namespace PetMonitoring.Temperature.Application.Commands.AddTemperature
{
    public sealed class AddTemperatureCommandHandler : IRequestHandler<AddTemperatureCommand, Unit>
    {
        private readonly ITemperatureRepository _repository;

        public AddTemperatureCommandHandler(ITemperatureRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(AddTemperatureCommand request, CancellationToken cancellationToken)
        {
            var record = TemperatureRecord.Create(request.PetId, request.DeviceId, request.CelsiusValue);
            await _repository.AddAsync(record);
            await _repository.SaveAsync();
            return Unit.Value;
        }
    }
}
