using MediatR;
using Microsoft.AspNetCore.Identity;
using PetMonitoring.Auth.Application.Commands.Login;
using PetMonitoring.Auth.Application.Enums;
using PetMonitoring.Auth.Domain.Entities;

namespace PetMonitoring.Auth.Application.Commands.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisterResult>
    {
        private readonly UserManager<User> _userManager;

        public RegisterCommandHandler(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<RegisterResult> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var user = new User(request.Name, request.Surname, request.UserName, request.Email);
            var result = await _userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
            {
                var message = string.Join(Environment.NewLine, result.Errors.Select(e => e.Description));
                return new RegisterResult(message: message, status: RequestStatus.Failed);
            }

            return new RegisterResult(
                name: user.Name!,
                surName: user.Surname!,
                userId: user.Id.ToString(),
                userName: user.UserName!,
                email: user.Email!,
                message: "Successfully registered.",
                status: RequestStatus.Success
            );
        }
    }
}