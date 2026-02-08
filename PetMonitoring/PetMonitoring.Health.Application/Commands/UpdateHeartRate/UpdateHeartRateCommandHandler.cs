using MediatR;
using PetMonitoring.Health.Application.Interfaces;
using PetMonitoring.Health.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetMonitoring.Health.Application.Commands.UpdateHeartRate
{
    public sealed class UpdateHeartRateCommandHandler : IRequestHandler<UpdateHeartRateCommand, Unit>
    {
        private readonly IHeartRateRepository _repository;

        public UpdateHeartRateCommandHandler(IHeartRateRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateHeartRateCommand request, CancellationToken cancellationToken)
        {
            var heartRateRecord = await  _repository.GetByIdAsync(request.Id, cancellationToken);
            if(heartRateRecord is not null)
            {
                heartRateRecord.UpdateBpm(request.Bpm);
                await _repository.SaveAsync();
            }
            
            return Unit.Value;
        }
    }
}
