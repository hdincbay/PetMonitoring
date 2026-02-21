namespace PetMonitoring.Auth.Application.Commands.Register
{
    public record RegisterResult
    {
        public string UserId { get; init; }
        public string UserName { get; init; }
        public string Email { get; init; }
        public string? Message { get; init; }

        public RegisterResult(string userId, string userName, string email, string? message = null)
        {
            UserId = userId;
            UserName = userName;
            Email = email;
            Message = message;
        }
    }
}