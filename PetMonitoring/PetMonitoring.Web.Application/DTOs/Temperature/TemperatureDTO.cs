using System;
using System.Collections.Generic;
using System.Text;

namespace PetMonitoring.Web.Application.DTOs.Temperature
{
    public record TemperatureDTO
    {
        public decimal CelsiusValue { get; private set; }
        public DateTime CreatedDate { get; set; }
    }
}
