using MediatR;
using PetMonitoring.Health.Application.Interfaces;
using PetMonitoring.Health.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetMonitoring.Health.Application.Queries
{
    public class GetHeartRateQueryHandler : IRequestHandler<GetHeartRateQuery, IEnumerable<HeartRateRecord>>
    {
        private readonly IHeartRateRepository _repository;

        public GetHeartRateQueryHandler(IHeartRateRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<HeartRateRecord>> Handle(GetHeartRateQuery request, CancellationToken cancellationToken)
        {
            var records = await _repository.GetByDeviceIdAsync(request.DeviceId, cancellationToken);
            return records;
        }
    }
}
