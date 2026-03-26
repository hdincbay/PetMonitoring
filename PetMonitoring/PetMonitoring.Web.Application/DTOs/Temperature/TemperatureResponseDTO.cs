using PetMonitoring.Web.Application.DTOs.Health;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetMonitoring.Web.Application.DTOs.Temperature
{
    public record TemperatureResponseDTO
    {
        public List<TemperatureDTO?> TemperatureList { get; } = new List<TemperatureDTO?>();
        public string? Message { get; }
        public int Status { get; }
    }
}
