using System;
using System.Collections.Generic;
using System.Text;

namespace PetMonitoring.Web.Application.DTOs.Health
{
    public record HealthDTO
    {
        public int Bpm { get;}
        public DateTime CreatedDate { get; }
    }
}
