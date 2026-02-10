using MediatR;
using PetMonitoring.Health.Application.Interfaces;
using PetMonitoring.Health.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetMonitoring.Health.Application.Commands.AddHeartRate
{
    public sealed class AddHeartRateCommandHandler : IRequestHandler<AddHeartRateCommand, Unit>
    {
        private readonly IHeartRateRepository _repository;

        public AddHeartRateCommandHandler(IHeartRateRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(AddHeartRateCommand request, CancellationToken cancellationToken)
        {
            var heartRateRecord = HeartRateRecord.Create(request.PetId, request.DeviceId, request.Bpm);
            await _repository.AddAsync(heartRateRecord, cancellationToken);
            return Unit.Value;
        }
    }
}
