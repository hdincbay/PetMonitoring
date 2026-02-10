using MediatR;
using PetMonitoring.DeviceManagement.Application.Interfaces;
using PetMonitoring.DeviceManagement.Domain.Entities;

namespace PetMonitoring.DeviceManagement.Application.Queries
{
    public class GetDeviceQueryHandler : IRequestHandler<GetDeviceQuery, DeviceRecord>
    {
        private readonly IDeviceRepository _repository;

        public GetDeviceQueryHandler(IDeviceRepository repository)
        {
            _repository = repository;
        }

        public async Task<DeviceRecord> Handle(GetDeviceQuery request, CancellationToken cancellationToken)
        {
            var record = await _repository.GetByDeviceIdAsync(request.DeviceId, cancellationToken);
            return record!;
        }
    }
}
