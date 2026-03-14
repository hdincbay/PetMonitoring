using MediatR;
using PetMonitoring.Temperature.Application.Enums;
using PetMonitoring.Temperature.Application.Interfaces;
using PetMonitoring.Temperature.Application.Results;
using PetMonitoring.Temperature.Domain.Entities;

namespace PetMonitoring.Temperature.Application.Commands.AddTemperature
{
    public sealed class AddTemperatureCommandHandler : IRequestHandler<AddTemperatureCommand, TemperatureOperationResult>
    {
        private readonly ITemperatureRepository _repository;

        public AddTemperatureCommandHandler(ITemperatureRepository repository)
        {
            _repository = repository;
        }

        public async Task<TemperatureOperationResult> Handle(AddTemperatureCommand request, CancellationToken cancellationToken)
        {
            var record = TemperatureRecord.Create(request.DeviceSerialNumber, request.CelsiusValue);
            var createResult = await _repository.AddAsync(record, cancellationToken);
            if (createResult == string.Empty)
            {
                return new TemperatureOperationResult(
                    "TemperatureRecord creation failed",
                    RequestStatus.Failed
                );
            }
            return new TemperatureOperationResult(
                $"TemperatureRecord with ID {createResult} created successfully",
                RequestStatus.Success
            );
        }
    }
}
