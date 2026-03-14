using Microsoft.AspNetCore.Mvc;
using PetMonitoring.Movement.Application.Enums;
using PetMonitoring.Movement.Application.Results;

namespace PetMonitoring.Movement.API.Mappers
{
    public static class RegisterResultExtensions
    {
        public static IActionResult ToActionResult(this MovementOperationResult result, ControllerBase controller)
        {
            if (result?.Status == null)
                return controller.StatusCode(500, result?.Message);

            return result.Status switch
            {
                RequestStatus.Success => controller.Ok(new { result.Message, result.Status }),
                RequestStatus.AlreadyExists => controller.Conflict(new { result.Message, result.Status }),
                RequestStatus.ValidationError => controller.BadRequest(new { result.Message, result.Status }),
                RequestStatus.NotFound => controller.BadRequest(new { result.Message, result.Status }),
                RequestStatus.Failed => controller.BadRequest(new { result.Message, result.Status }),
                _ => controller.StatusCode(500, result.Message)
            };
        }
        public static IActionResult ToMovementResult(this MovementOperationResult result, ControllerBase controller)
        {
            if (result?.Status == null)
                return controller.StatusCode(500, result?.Message);

            return result.Status switch
            {
                RequestStatus.Success => controller.Ok(new { result.Message, result.Status, result.Movement }),
                RequestStatus.AlreadyExists => controller.Conflict(new { result.Message, result.Status }),
                RequestStatus.ValidationError => controller.BadRequest(new { result.Message, result.Status }),
                RequestStatus.NotFound => controller.BadRequest(new { result.Message, result.Status }),
                RequestStatus.Failed => controller.BadRequest(new { result.Message, result.Status }),
                _ => controller.StatusCode(500, result.Message)
            };
        }
        public static IActionResult ToMovementListResult(this MovementOperationResult result, ControllerBase controller)
        {
            if (result?.Status == null)
                return controller.StatusCode(500, result?.Message);

            return result.Status switch
            {
                RequestStatus.Success => controller.Ok(new { result.Message, result.Status, result.MovementList }),
                RequestStatus.AlreadyExists => controller.Conflict(new { result.Message, result.Status }),
                RequestStatus.ValidationError => controller.BadRequest(new { result.Message, result.Status }),
                RequestStatus.NotFound => controller.BadRequest(new { result.Message, result.Status }),
                RequestStatus.Failed => controller.BadRequest(new { result.Message, result.Status }),
                _ => controller.StatusCode(500, result.Message)
            };
        }
    }
}
