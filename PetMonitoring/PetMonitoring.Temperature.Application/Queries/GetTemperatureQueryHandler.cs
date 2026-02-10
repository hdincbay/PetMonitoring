using MediatR;
using PetMonitoring.Temperature.Application.Interfaces;
using PetMonitoring.Temperature.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetMonitoring.Temperature.Application.Queries
{
    public class GetTemperatureQueryHandler : IRequestHandler<GetTemperatureQuery, TemperatureRecord>
    {
        private readonly ITemperatureRepository _repository;

        public GetTemperatureQueryHandler(ITemperatureRepository repository)
        {
            _repository = repository;
        }

        public async Task<TemperatureRecord> Handle(GetTemperatureQuery request, CancellationToken cancellationToken)
        {
            var record = await _repository.GetByDeviceIdAsync(request.DeviceId, cancellationToken);
            return record;
        }
    }
}
