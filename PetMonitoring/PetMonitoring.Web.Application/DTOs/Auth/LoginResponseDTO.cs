using System;
using System.Collections.Generic;
using System.Text;

namespace PetMonitoring.Web.Application.DTOs.Auth
{
    public record LoginResponseDTO
    {
        public Guid UserId { get; }
        public string? UserName { get; }
        public List<string?> Roles = new List<string?>();
        public string? AccessToken { get; }
        public string? RefreshToken { get; }
        public string? Message { get; }
    }
}
