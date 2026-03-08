using Microsoft.AspNetCore.Mvc;
using PetMonitoring.Health.Application.Enums;
using PetMonitoring.Health.Application.Results;

namespace PetMonitoring.Health.API.Mappers
{
    public static class RegisterResultExtensions
    {
        public static IActionResult ToActionResult(this HealthOperationResult result, ControllerBase controller)
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
        public static IActionResult ToHealthResult(this HealthOperationResult result, ControllerBase controller)
        {
            if (result?.Status == null)
                return controller.StatusCode(500, result?.Message);

            return result.Status switch
            {
                RequestStatus.Success => controller.Ok(new { result.Message, result.Status, result.HeartRate }),
                RequestStatus.AlreadyExists => controller.Conflict(new { result.Message, result.Status }),
                RequestStatus.ValidationError => controller.BadRequest(new { result.Message, result.Status }),
                RequestStatus.NotFound => controller.BadRequest(new { result.Message, result.Status }),
                RequestStatus.Failed => controller.BadRequest(new { result.Message, result.Status }),
                _ => controller.StatusCode(500, result.Message)
            };
        }
        public static IActionResult ToHealthListResult(this HealthOperationResult result, ControllerBase controller)
        {
            if (result?.Status == null)
                return controller.StatusCode(500, result?.Message);

            return result.Status switch
            {
                RequestStatus.Success => controller.Ok(new { result.Message, result.Status, result.HeartRateList }),
                RequestStatus.AlreadyExists => controller.Conflict(new { result.Message, result.Status }),
                RequestStatus.ValidationError => controller.BadRequest(new { result.Message, result.Status }),
                RequestStatus.NotFound => controller.BadRequest(new { result.Message, result.Status }),
                RequestStatus.Failed => controller.BadRequest(new { result.Message, result.Status }),
                _ => controller.StatusCode(500, result.Message)
            };
        }
    }
}
