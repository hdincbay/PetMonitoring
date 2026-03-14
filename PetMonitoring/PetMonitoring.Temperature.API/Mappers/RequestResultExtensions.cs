using Microsoft.AspNetCore.Mvc;
using PetMonitoring.Temperature.Application.Enums;
using PetMonitoring.Temperature.Application.Results;

namespace PetMonitoring.Temperature.API.Mappers
{
    public static class RegisterResultExtensions
    {
        public static IActionResult ToActionResult(this TemperatureOperationResult result, ControllerBase controller)
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
        public static IActionResult ToTemperatureResult(this TemperatureOperationResult result, ControllerBase controller)
        {
            if (result?.Status == null)
                return controller.StatusCode(500, result?.Message);

            return result.Status switch
            {
                RequestStatus.Success => controller.Ok(new { result.Message, result.Status, result.Temperature }),
                RequestStatus.AlreadyExists => controller.Conflict(new { result.Message, result.Status }),
                RequestStatus.ValidationError => controller.BadRequest(new { result.Message, result.Status }),
                RequestStatus.NotFound => controller.BadRequest(new { result.Message, result.Status }),
                RequestStatus.Failed => controller.BadRequest(new { result.Message, result.Status }),
                _ => controller.StatusCode(500, result.Message)
            };
        }
        public static IActionResult ToTemperatureListResult(this TemperatureOperationResult result, ControllerBase controller)
        {
            if (result?.Status == null)
                return controller.StatusCode(500, result?.Message);

            return result.Status switch
            {
                RequestStatus.Success => controller.Ok(new { result.Message, result.Status, result.TemperatureList }),
                RequestStatus.AlreadyExists => controller.Conflict(new { result.Message, result.Status }),
                RequestStatus.ValidationError => controller.BadRequest(new { result.Message, result.Status }),
                RequestStatus.NotFound => controller.BadRequest(new { result.Message, result.Status }),
                RequestStatus.Failed => controller.BadRequest(new { result.Message, result.Status }),
                _ => controller.StatusCode(500, result.Message)
            };
        }
    }
}
