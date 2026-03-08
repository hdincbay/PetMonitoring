using System;
using System.Collections.Generic;
using System.Text;

namespace PetMonitoring.Web.Application.DTOs
{
    public record HealthDTO
    {
        public int Bpm { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
