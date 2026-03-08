using MediatR;
using PetMonitoring.DeviceManagement.Application.Enums;
using PetMonitoring.DeviceManagement.Application.Interfaces;
using PetMonitoring.DeviceManagement.Application.Results;
using PetMonitoring.DeviceManagement.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PetMonitoring.DeviceManagement.Application.Commands.BatteryUpdateCommand
{
    public sealed class BatteryUpdateCommandHandler : IRequestHandler<BatteryUpdateCommand, DeviceOperationResult>
    {
        private readonly IDeviceRepository _repository;

        public BatteryUpdateCommandHandler(IDeviceRepository repository)
        {
            _repository = repository;
        }

        public async Task<DeviceOperationResult> Handle(BatteryUpdateCommand request, CancellationToken cancellationToken)
        {
            var record = await _repository.GetByDeviceIdAsync(request.ID, cancellationToken);

            if (record is null)
            {
                return new DeviceOperationResult(
                    request.SerialNumber,
                    $"Device with Serial Number {request.SerialNumber} not found",
                    RequestStatus.NotFound
                );
            }

            record.UpdateBatteryPercentage(request.BatteryPercentage);
            var updateResult = await _repository.UpdateAsync(record, cancellationToken);

            if (!updateResult)
            {
                return new DeviceOperationResult(
                    request.SerialNumber,
                    $"Battery update failed for Device Serial Number {request.SerialNumber}",
                    RequestStatus.Failed
                );
            }

            return new DeviceOperationResult(
                request.SerialNumber,
                $"Battery updated to {request.BatteryPercentage}% for Device Serial Number {request.SerialNumber}",
                RequestStatus.Success
            );
        }
    }
}