using AutoMapper;
using MediatR;
using PetMonitoring.Temperature.Application.DTOs;
using PetMonitoring.Temperature.Application.Enums;
using PetMonitoring.Temperature.Application.Interfaces;
using PetMonitoring.Temperature.Application.Results;
using PetMonitoring.Temperature.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetMonitoring.Temperature.Application.Queries
{
    public class GetTemperaturesQueryHandler : IRequestHandler<GetTemperaturesQuery, TemperatureOperationResult>
    {
        private readonly IMapper _mapper;
        private readonly ITemperatureRepository _repository;

        public GetTemperaturesQueryHandler(ITemperatureRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<TemperatureOperationResult> Handle(GetTemperaturesQuery request, CancellationToken cancellationToken)
        {
            var recordList = await _repository.GetByDeviceSerialNumberAsync(request.DeviceSerialNumber, cancellationToken);
            if (recordList is null)
            {
                return new TemperatureOperationResult
                (
                    $"No temperature record found for device with serial number {request.DeviceSerialNumber}.",
                    RequestStatus.NotFound
                );
            }
            var dtoList = _mapper.Map<List<TemperatureRecordDTO>>(recordList);
            return new TemperatureOperationResult
            (
                "Temperature record retrieved successfully.",
                RequestStatus.Success,
                dtoList
            );
        }
    }
}
