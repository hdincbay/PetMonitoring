using PetMonitoring.Auth.Application.Enums;
using System.Net;

namespace PetMonitoring.Auth.Application.Commands.Login
{
    public record LoginResult
    {
        public string? AccessToken { get; init; }
        public string? RefreshToken { get; init; }
        public string? Message { get; init; }
        public RequestStatus Status { get; set; }
        public LoginResult() { }
        public LoginResult(string message, RequestStatus status)
        {
            Message = message;
            Status = status;
        }
        public LoginResult(string? accessToken, string? refreshToken, string? message, RequestStatus status)
        {
            AccessToken = accessToken;
            RefreshToken = refreshToken;
            Message = message;
            Status = status;
        }
    }
}