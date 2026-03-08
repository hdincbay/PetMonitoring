using AutoMapper;
using MediatR;
using PetMonitoring.Health.Application.DTOs;
using PetMonitoring.Health.Application.Enums;
using PetMonitoring.Health.Application.Interfaces;
using PetMonitoring.Health.Application.Results;
using PetMonitoring.Health.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;

namespace PetMonitoring.Health.Application.Queries
{
    public class GetHeartRateQueryHandler : IRequestHandler<GetHeartRateQuery, HealthOperationResult>
    {
        private readonly IHeartRateRepository _repository;
        private readonly IMapper _mapper;

        public GetHeartRateQueryHandler(IHeartRateRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<HealthOperationResult> Handle(GetHeartRateQuery request, CancellationToken cancellationToken)
        {
            var record = await _repository.GetByDeviceSerialNumberAsync(request.DeviceSerialNumber, cancellationToken);
            if(record is null)
            {
                return new HealthOperationResult
                (
                    $"No heart rate record found for device with serial number {request.DeviceSerialNumber}.",
                    RequestStatus.NotFound
                );
            }
            var dto = _mapper.Map<HeartRateRecordDTO>(record);
            return new HealthOperationResult
            (
                "Heart rate record retrieved successfully.",
                RequestStatus.Success,
                dto
            );
        }
    }
}
