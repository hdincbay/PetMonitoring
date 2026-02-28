using AutoMapper;
using MediatR;
using PetMonitoring.DeviceManagement.Application.DTOs;
using PetMonitoring.DeviceManagement.Application.Enums;
using PetMonitoring.DeviceManagement.Application.Interfaces;
using PetMonitoring.DeviceManagement.Application.Results;
using PetMonitoring.DeviceManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PetMonitoring.DeviceManagement.Application.Queries
{
    public class GetDevicesQueryHandler : IRequestHandler<GetDevicesQuery, DeviceOperationResult>
    {
        private readonly IDeviceRepository _deviceRepository;
        private readonly IMapper _mapper;

        public GetDevicesQueryHandler(IDeviceRepository deviceRepository, IMapper mapper)
        {
            _deviceRepository = deviceRepository;
            _mapper = mapper;
        }

        public async Task<DeviceOperationResult> Handle(GetDevicesQuery request, CancellationToken cancellationToken)
        {
            var recordList = await _deviceRepository.GetAllAsync(cancellationToken);

            if (recordList == null)
            {
                return new DeviceOperationResult(
                    "No devices found",
                    RequestStatus.NotFound
                );
            }

            var dtoList = _mapper.Map<IEnumerable<DeviceRecordDTO>>(recordList);

            return new DeviceOperationResult(
                "Devices retrieved successfully",
                RequestStatus.Success,
                dtoList
            );
        }
    }
}