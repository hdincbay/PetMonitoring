using AutoMapper;
using MediatR;
using PetMonitoring.DeviceManagement.Application.DTOs;
using PetMonitoring.DeviceManagement.Application.Enums;
using PetMonitoring.DeviceManagement.Application.Interfaces;
using PetMonitoring.DeviceManagement.Application.Results;
using PetMonitoring.DeviceManagement.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PetMonitoring.DeviceManagement.Application.Queries
{
    public class GetDeviceQueryHandler : IRequestHandler<GetDeviceQuery, DeviceOperationResult>
    {
        private readonly IDeviceRepository _repository;
        private readonly IMapper _mapper;

        public GetDeviceQueryHandler(IDeviceRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<DeviceOperationResult> Handle(GetDeviceQuery request, CancellationToken cancellationToken)
        {
            var record = await _repository.GetByDeviceIdAsync(request.DeviceId, cancellationToken);

            if (record is null)
            {
                return new DeviceOperationResult(
                    $"Device with Serial Number {request.SerialNumber} not found",
                    RequestStatus.NotFound
                );
            }

            var dto = _mapper.Map<DeviceRecordDTO>(record);

            return new DeviceOperationResult(
                "Device retrieved successfully",
                RequestStatus.Success,
                dto
            );
        }
    }
}