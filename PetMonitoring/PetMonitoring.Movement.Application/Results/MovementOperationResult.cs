using PetMonitoring.Movement.Application.DTOs;
using PetMonitoring.Movement.Application.Enums;
namespace PetMonitoring.Movement.Application.Results
{
    public class MovementOperationResult
    {
        public string? Message { get; set; }
        public RequestStatus Status { get; set; }
        public MovementRecordDTO Movement { get; set; } = new MovementRecordDTO();
        public IEnumerable<MovementRecordDTO> MovementList { get; set; } = new List<MovementRecordDTO>();
        public MovementOperationResult(string message, RequestStatus status)
        {
            Message = message;
            Status = status;
        }
        public MovementOperationResult(string message, RequestStatus status, MovementRecordDTO movement)
        {
            Message = message;
            Status = status;
            Movement = movement;
        }
        public MovementOperationResult(string message, RequestStatus status, IEnumerable<MovementRecordDTO> movementList)
        {
            Message= message;
            Status = status;
            MovementList = movementList;
        }

    }
}
