using MediatR;
using PetMonitoring.DeviceManagement.Application.Enums;
using PetMonitoring.DeviceManagement.Application.Interfaces;
using PetMonitoring.DeviceManagement.Application.Results;
using PetMonitoring.DeviceManagement.Domain.Entities;

namespace PetMonitoring.DeviceManagement.Application.Commands.CreateDeviceCommand
{
    public sealed class CreateDeviceCommandHandler : IRequestHandler<CreateDeviceCommand, DeviceOperationResult>
    {
        private readonly IDeviceRepository _repository;

        public CreateDeviceCommandHandler(IDeviceRepository repository)
        {
            _repository = repository;
        }

        public async Task<DeviceOperationResult> Handle(CreateDeviceCommand request, CancellationToken cancellationToken)
        {
            var device = await _repository.GetBySerialNumberAsync(request.SerialNumber, cancellationToken);
            if(device is not null)
            {
                return new DeviceOperationResult(
                    $"A device with Serial Number {request.SerialNumber} already exists.",
                    RequestStatus.Failed
                );
            }
            var record = DeviceRecord.Create(request.Name, request.PetName, request.SerialNumber);
            var createResult = await _repository.CreateAsync(record, cancellationToken);

            if (createResult == string.Empty)
            {
                return new DeviceOperationResult(
                    "Device creation failed",
                    RequestStatus.Failed
                );
            }
            return new DeviceOperationResult(
                createResult,
                $"Device with Serial Number {createResult} created successfully",
                RequestStatus.Success
            );
        }
    }
}