using MediatR;
using PetMonitoring.Auth.Application.Commands.Register;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetMonitoring.Auth.Application.Commands.Login
{
    public sealed class LoginCommand : IRequest<LoginResult>
    {
        public string? UserName { get; set; }
        public string Password { get; }

        public LoginCommand(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }
    }
}
