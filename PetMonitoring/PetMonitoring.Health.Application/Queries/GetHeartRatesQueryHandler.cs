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
    public class GetHeartRatesQueryHandler : IRequestHandler<GetHeartRatesQuery, HealthOperationResult>
    {
        private readonly IHeartRateRepository _repository;
        private readonly IMapper _mapper;

        public GetHeartRatesQueryHandler(IHeartRateRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<HealthOperationResult> Handle(GetHeartRatesQuery request, CancellationToken cancellationToken)
        {
            var recordList = await _repository.GetByDeviceSerialNumberAsync(request.DeviceSerialNumber, cancellationToken);
            if(recordList is null)
            {
                return new HealthOperationResult
                (
                    $"No heart rate record found for device with serial number {request.DeviceSerialNumber}.",
                    RequestStatus.NotFound
                );
            }
            var dtoList = _mapper.Map<List<HeartRateRecordDTO>>(recordList);
            return new HealthOperationResult
            (
                "Heart rate record retrieved successfully.",
                RequestStatus.Success,
                dtoList
            );
        }
    }
}
