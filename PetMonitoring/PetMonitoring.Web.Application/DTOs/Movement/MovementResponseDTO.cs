using PetMonitoring.Web.Application.DTOs.Health;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetMonitoring.Web.Application.DTOs.Movement
{
    public record MovementResponseDTO
    {
        public List<MovementDTO?> MovementList { get; } = new List<MovementDTO?>();
        public string? Message { get; }
        public int Status { get; }
    }
}
