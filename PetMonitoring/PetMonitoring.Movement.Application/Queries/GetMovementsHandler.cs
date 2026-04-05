using AutoMapper;
using MediatR;
using PetMonitoring.Movement.Application.DTOs;
using PetMonitoring.Movement.Application.Enums;
using PetMonitoring.Movement.Application.Interfaces;
using PetMonitoring.Movement.Application.Results;
using PetMonitoring.Movement.Domain.Entities;

namespace PetMonitoring.Movement.Application.Queries
{
    public class GetMovementsHandler : IRequestHandler<GetMovementsQuery, MovementOperationResult>
    {
        private readonly IMovementRepository _repository;
        private readonly IMapper _mapper;

        public GetMovementsHandler(IMovementRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<MovementOperationResult> Handle(GetMovementsQuery request, CancellationToken cancellationToken)
        {
            var recordList = await _repository.GetByDeviceSerialNumberAsync(request.DeviceSerialNumber, cancellationToken);
            if (recordList is null)
            {
                return new MovementOperationResult
                (
                    $"No movement record found for device with serial number {request.DeviceSerialNumber}.",
                    RequestStatus.NotFound
                );
            }
            var dtoList = _mapper.Map<List<MovementRecordDTO>>(recordList);
            return new MovementOperationResult
            (
                "Movement record retrieved successfully.",
                RequestStatus.Success,
                dtoList
            );
        }
    }
}
