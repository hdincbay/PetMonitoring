using MediatR;
using PetMonitoring.DeviceManagement.Application.Interfaces;
using PetMonitoring.DeviceManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetMonitoring.DeviceManagement.Application.Commands.AddDeviceCommand
{
    public sealed class AddDeviceCommandHandler : IRequestHandler<AddDeviceCommand, Unit>
    {
        private readonly IDeviceRepository _repository;

        public AddDeviceCommandHandler(IDeviceRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(AddDeviceCommand request, CancellationToken cancellationToken)
        {
            var record = DeviceRecord.Create(request.Name);
            await _repository.AddAsync(record, cancellationToken);
            return Unit.Value;
        }
    }
}
