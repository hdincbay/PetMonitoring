using System;
using System.Collections.Generic;
using System.Text;

namespace PetMonitoring.Web.Application.DTOs
{
    public class HealthResponseDTO
    {
        public HealthDTO? Health { get; set; }
        public List<HealthDTO?> HealthList { get; set; } = new List<HealthDTO?>();
        public string? Message { get; set; }
        public int Status { get; set; }
    }
}
