using MediatR;
using PetMonitoring.DeviceManagement.Application.Interfaces;
using PetMonitoring.DeviceManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetMonitoring.DeviceManagement.Application.Commands.UpdateDeviceCommand
{
    public sealed class UpdateDeviceCommandHandler : IRequestHandler<UpdateDeviceCommand, Unit>
    {
        private readonly IDeviceRepository _repository;

        public UpdateDeviceCommandHandler(IDeviceRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateDeviceCommand request, CancellationToken cancellationToken)
        {
            var record = await _repository.GetByDeviceIdAsync(request.DeviceId, cancellationToken);
            if (record is null)
            {
                throw new KeyNotFoundException("Record Number " + request.DeviceId + " Not Found");
            }
            record.Update(request.Name, request.PetName);
            await _repository.UpdateAsync(record, cancellationToken);
            return Unit.Value;
        }
    }
}
