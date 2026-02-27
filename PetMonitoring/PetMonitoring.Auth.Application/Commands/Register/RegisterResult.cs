using PetMonitoring.Auth.Application.Enums;
using System.Net;

namespace PetMonitoring.Auth.Application.Commands.Register
{
    public record RegisterResult
    {
        public string? UserId { get; init; }
        public string? UserName { get; init; }
        public string? Email { get; init; }
        public string? Message { get; init; }
        public RequestStatus Status { get; set; }
        public RegisterResult() { }
        public RegisterResult(string message, RequestStatus status)
        {
            Message = message;
            Status = status;
        }
        public RegisterResult(string userId, string userName, string email, string? message, RequestStatus status)
        {
            UserId = userId;
            UserName = userName;
            Email = email;
            Message = message;
            Status = status;
        }
    }
}