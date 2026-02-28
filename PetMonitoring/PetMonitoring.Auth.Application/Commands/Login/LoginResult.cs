using PetMonitoring.Auth.Application.Enums;
using System.Net;

namespace PetMonitoring.Auth.Application.Commands.Login
{
    public record LoginResult
    {
        public Guid UserId { get; set; }
        public string? UserName { get; set; }
        public IList<string> Roles = new List<string>();
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
        public LoginResult(string? accessToken, string? refreshToken, string? message, RequestStatus status, Guid userId, string? userName, IList<string> roles)
        {
            AccessToken = accessToken;
            RefreshToken = refreshToken;
            Message = message;
            Status = status;
            UserId = userId;
            UserName = userName;
            Roles = roles;
        }
    }
}