using MediatR;
using PetMonitoring.DeviceManagement.Application.Interfaces;
using PetMonitoring.DeviceManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetMonitoring.DeviceManagement.Application.Commands.AddDeviceCommand
{
    public sealed class CreateDeviceCommandHandler : IRequestHandler<CreateDeviceCommand, Unit>
    {
        private readonly IDeviceRepository _repository;

        public CreateDeviceCommandHandler(IDeviceRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(CreateDeviceCommand request, CancellationToken cancellationToken)
        {
            var record = DeviceRecord.Create(request.Name);
            await _repository.AddAsync(record, cancellationToken);
            return Unit.Value;
        }
    }
}
