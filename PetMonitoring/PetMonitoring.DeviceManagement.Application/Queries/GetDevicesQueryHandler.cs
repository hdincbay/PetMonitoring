using AutoMapper;
using MediatR;
using PetMonitoring.DeviceManagement.Application.DTOs;
using PetMonitoring.DeviceManagement.Application.Interfaces;
using PetMonitoring.DeviceManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetMonitoring.DeviceManagement.Application.Queries
{
    public class GetDevicesQueryHandler : IRequestHandler<GetDevicesQuery, IEnumerable<DeviceDTO>>
    {
        private readonly IDeviceRepository _deviceRepository;
        private readonly IMapper _mapper;

        public GetDevicesQueryHandler(IDeviceRepository deviceRepository, IMapper mapper)
        {
            _deviceRepository = deviceRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DeviceDTO>> Handle(GetDevicesQuery request, CancellationToken cancellationToken)
        {
            var recordList = await _deviceRepository.GetAllAsync(cancellationToken);
            return _mapper.Map<IEnumerable<DeviceDTO>>(recordList);

        }
    }
}
