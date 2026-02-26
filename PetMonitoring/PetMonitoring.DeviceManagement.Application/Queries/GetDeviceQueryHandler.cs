using AutoMapper;
using MediatR;
using PetMonitoring.DeviceManagement.Application.DTOs;
using PetMonitoring.DeviceManagement.Application.Interfaces;
using PetMonitoring.DeviceManagement.Domain.Entities;

namespace PetMonitoring.DeviceManagement.Application.Queries
{
    public class GetDeviceQueryHandler : IRequestHandler<GetDeviceQuery, DeviceDTO>
    {
        private readonly IDeviceRepository _repository;
        private readonly IMapper _mapper;

        public GetDeviceQueryHandler(IDeviceRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<DeviceDTO> Handle(GetDeviceQuery request, CancellationToken cancellationToken)
        {
            var record = await _repository.GetByDeviceIdAsync(request.DeviceId, cancellationToken);
            return _mapper.Map<DeviceDTO>(record);
        }
    }
}
