using MediatR;
using PetMonitoring.DeviceManagement.Application.Interfaces;
using PetMonitoring.DeviceManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetMonitoring.DeviceManagement.Application.Commands.BatteryUpdateCommand
{
    public sealed class BatteryUpdateCommandHandler : IRequestHandler<BatteryUpdateCommand, Unit>
    {
        private readonly IDeviceRepository _repository;

        public BatteryUpdateCommandHandler(IDeviceRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(BatteryUpdateCommand request, CancellationToken cancellationToken)
        {
            var record = await _repository.GetByDeviceIdAsync(request.DeviceId, cancellationToken);
            if (record is null)
            {
                throw new KeyNotFoundException("Record Number " + request.DeviceId + " Not Found");
            }
            record.UpdateBatteryPercentage(request.BatteryPercentage);
            await _repository.UpdateAsync(record, cancellationToken);
            return Unit.Value;
        }
    }
}
