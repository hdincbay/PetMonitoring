using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetMonitoring.Auth.Application.Commands.Register
{
    public sealed class RegisterCommand : IRequest<RegisterResult>
    {
        public string Name { get; }
        public string Surname { get; }
        public string UserName { get; }
        public string Email { get; }
        public string Password { get; }

        public RegisterCommand(string name, string surName, string userName, string email, string password)
        {
            Name = name;
            Surname = surName;
            Email = email;
            Password = password;
            UserName = userName;
        }
    }
}
