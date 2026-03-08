using MediatR;
using PetMonitoring.Health.Application.Enums;
using PetMonitoring.Health.Application.Interfaces;
using PetMonitoring.Health.Application.Results;
using PetMonitoring.Health.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetMonitoring.Health.Application.Commands.AddHeartRate
{
    public sealed class AddHeartRateCommandHandler : IRequestHandler<AddHeartRateCommand, HealthOperationResult>
    {
        private readonly IHeartRateRepository _repository;

        public AddHeartRateCommandHandler(IHeartRateRepository repository)
        {
            _repository = repository;
        }

        public async Task<HealthOperationResult> Handle(AddHeartRateCommand request, CancellationToken cancellationToken)
        {
            var record = HeartRateRecord.Create(request.DeviceSerialNumber, request.Bpm);
            var createResult = await _repository.AddAsync(record, cancellationToken);

            if (createResult == string.Empty)
            {
                return new HealthOperationResult(
                    "Device creation failed",
                    RequestStatus.Failed
                );
            }
            return new HealthOperationResult(
                $"HartRateRecord with ID {createResult} created successfully",
                RequestStatus.Success
            );
        }
    }
}
