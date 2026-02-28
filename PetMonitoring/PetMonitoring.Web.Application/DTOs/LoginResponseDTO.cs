using System;
using System.Collections.Generic;
using System.Text;

namespace PetMonitoring.Web.Application.DTOs
{
    public record LoginResponseDTO
    {
        public Guid UserId { get; set; }
        public string? UserName { get; set; }
        public List<string?> Roles = new List<string?>();
        public string? AccessToken { get; set; }
        public string? RefreshToken { get; set; }
        public string? Message { get; set; }
    }
}
