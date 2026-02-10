using MediatR;
using PetMonitoring.Movement.Application.Interfaces;
using PetMonitoring.Movement.Domain.Entities;

namespace PetMonitoring.Movement.Application.Queries
{
    public class GetMovementHandler : IRequestHandler<GetMovementQuery, MovementRecord>
    {
        private readonly IMovementRepository _repository;

        public GetMovementHandler(IMovementRepository repository)
        {
            _repository = repository;
        }

        public async Task<MovementRecord> Handle(GetMovementQuery request, CancellationToken cancellationToken)
        {
            var record = await _repository.GetByDeviceIdAsync(request.DeviceId, cancellationToken);
            return record!;
        }
    }
}
