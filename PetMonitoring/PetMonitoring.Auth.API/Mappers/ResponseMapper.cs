using Microsoft.AspNetCore.Mvc;
using PetMonitoring.Auth.Application.Commands.Login;
using PetMonitoring.Auth.Application.Commands.Register;
using PetMonitoring.Auth.Application.Enums;
using System.Net;

namespace PetMonitoring.Auth.API.Mappers
{
    public static class RegisterResultExtensions
    {
        public static IActionResult LoginResult(this LoginResult result, ControllerBase controller)
        {
            if (result?.Status == null)
                return controller.StatusCode(500, result?.Message);

            return result.Status switch
            {
                RequestStatus.Success => controller.Ok(new { result.AccessToken, result.RefreshToken, result.Message, result.Status, result.UserId, result.UserName, result.Roles }),
                RequestStatus.AlreadyExists => controller.Conflict(result.Message),
                RequestStatus.ValidationError => controller.BadRequest(result.Message),
                _ => controller.StatusCode(500, result.Message)
            };
        }
        public static IActionResult RegisterResult(this RegisterResult result, ControllerBase controller)
        {
            if (result?.Status == null)
                return controller.StatusCode(500, result?.Message);

            return result.Status switch
            {
                RequestStatus.Success => controller.Ok(new { result.UserId, result.UserName, result.Email, result.Message }),
                RequestStatus.AlreadyExists => controller.Conflict(result.Message),
                RequestStatus.ValidationError => controller.BadRequest(result.Message),
                _ => controller.StatusCode(500, result.Message)
            };
        }
    }
}
