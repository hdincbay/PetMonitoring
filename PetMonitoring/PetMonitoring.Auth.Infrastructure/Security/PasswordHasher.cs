using Microsoft.AspNetCore.Identity;
using PetMonitoring.Auth.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetMonitoring.Auth.Infrastructure.Security
{
    public class PasswordHasher : IPasswordHasher
    {
        public string Hash(string password)
            => BCrypt.Net.BCrypt.HashPassword(password);

        public bool Verify(string password, string hashedPassword)
            => BCrypt.Net.BCrypt.Verify(password, hashedPassword);
    }
}
