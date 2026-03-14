using MediatR;
using PetMonitoring.DeviceManagement.Application.Interfaces;
using PetMonitoring.DeviceManagement.Domain.Entities;
using PetMonitoring.DeviceManagement.Application.Enums;
using PetMonitoring.DeviceManagement.Application.Results;

namespace PetMonitoring.DeviceManagement.Application.Commands.UpdateDeviceCommand
{
    public sealed class UpdateDeviceCommandHandler : IRequestHandler<UpdateDeviceCommand, DeviceOperationResult>
    {
        private readonly IDeviceRepository _repository;

        public UpdateDeviceCommandHandler(IDeviceRepository repository)
        {
            _repository = repository;
        }

        public async Task<DeviceOperationResult> Handle(UpdateDeviceCommand request, CancellationToken cancellationToken)
        {
            var record = await _repository.GetByDeviceIdAsync(request.ID, cancellationToken);
            if (record is null)
            {
                return new DeviceOperationResult(
                    $"Device with ID {request.ID} not found",
                    RequestStatus.Failed
                );
            }
            record.Update(request.SerialNumber, request.Name, request.PetName, request.IsDeleted, request.DeletedDate);
            var success = await _repository.UpdateAsync(record, cancellationToken);

            if (!success)
            {
                return new DeviceOperationResult(
                    $"No changes were applied to Device with ID Serial Number {request.SerialNumber}",
                    RequestStatus.Failed
                );
            }

            return new DeviceOperationResult(
                $"Device with Serial Number {request.SerialNumber} updated successfully",
                RequestStatus.Success
            );
        }
    }
}