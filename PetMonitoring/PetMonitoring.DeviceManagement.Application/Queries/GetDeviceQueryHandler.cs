using AutoMapper;
using MediatR;
using PetMonitoring.DeviceManagement.Application.DTOs;
using PetMonitoring.DeviceManagement.Application.Interfaces;
using PetMonitoring.DeviceManagement.Domain.Entities;

namespace PetMonitoring.DeviceManagement.Application.Queries
{
    public class GetDeviceQueryHandler : IRequestHandler<GetDeviceQuery, DeviceRecordDTO>
    {
        private readonly IDeviceRepository _repository;
        private readonly IMapper _mapper;

        public GetDeviceQueryHandler(IDeviceRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<DeviceRecordDTO> Handle(GetDeviceQuery request, CancellationToken cancellationToken)
        {
            var record = await _repository.GetByDeviceIdAsync(request.DeviceId, cancellationToken);
            return _mapper.Map<DeviceRecordDTO>(record);
        }
    }
}
