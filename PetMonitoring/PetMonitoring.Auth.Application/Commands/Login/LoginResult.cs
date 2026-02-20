using System;
using System.Collections.Generic;
using System.Text;

namespace PetMonitoring.Auth.Application.Commands.Login
{
    public sealed class LoginResult
    {
        public string? AccessToken { get; set; }
        public string? RefreshToken { get; set; }
    }
}
