using Microsoft.AspNetCore.Mvc;
using PetMonitoring.DeviceManagement.Application.Commands.CreateDeviceCommand;
using PetMonitoring.DeviceManagement.Application.Enums;
using PetMonitoring.DeviceManagement.Application.Results;

namespace PetMonitoring.DeviceManagement.API.Mappers
{
    public static class RegisterResultExtensions
    {
        public static IActionResult ToActionResult(this DeviceOperationResult result, ControllerBase controller)
        {
            if (result?.Status == null)
                return controller.StatusCode(500, result?.Message);

            return result.Status switch
            {
                RequestStatus.Success => controller.Ok(new { result.SerialNumber, result.Message, result.Status }),
                RequestStatus.AlreadyExists => controller.Conflict(new { result.Message, result.Status }),
                RequestStatus.ValidationError => controller.BadRequest(new { result.Message, result.Status }),
                RequestStatus.NotFound => controller.BadRequest(new { result.Message, result.Status }),
                RequestStatus.Failed => controller.BadRequest(new { result.Message, result.Status }),
                _ => controller.StatusCode(500, result.Message)
            };
        }
        public static IActionResult ToDeviceResult(this DeviceOperationResult result, ControllerBase controller)
        {
            if (result?.Status == null)
                return controller.StatusCode(500, result?.Message);

            return result.Status switch
            {
                RequestStatus.Success => controller.Ok(new { result.Message, result.Status, result.Device }),
                RequestStatus.AlreadyExists => controller.Conflict(new { result.Message, result.Status }),
                RequestStatus.ValidationError => controller.BadRequest(new { result.Message, result.Status }),
                RequestStatus.NotFound => controller.BadRequest(new { result.Message, result.Status }),
                RequestStatus.Failed => controller.BadRequest(new { result.Message, result.Status }),
                _ => controller.StatusCode(500, result.Message)
            };
        }
        public static IActionResult ToDeviceListResult(this DeviceOperationResult result, ControllerBase controller)
        {
            if (result?.Status == null)
                return controller.StatusCode(500, result?.Message);

            return result.Status switch
            {
                RequestStatus.Success => controller.Ok(new { result.Message, result.Status, result.DeviceList }),
                RequestStatus.AlreadyExists => controller.Conflict(new { result.Message, result.Status }),
                RequestStatus.ValidationError => controller.BadRequest(new { result.Message, result.Status }),
                RequestStatus.NotFound => controller.BadRequest(new { result.Message, result.Status }),
                RequestStatus.Failed => controller.BadRequest(new { result.Message, result.Status }),
                _ => controller.StatusCode(500, result.Message)
            };
        }
    }
}
