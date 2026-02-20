using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetMonitoring.Auth.Application.Commands.Login
{
    public sealed class LoginCommand : IRequest<LoginResult>
    {
        public string Email { get; }
        public string Password { get; }

        public LoginCommand(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
