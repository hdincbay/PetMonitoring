using System;
using System.Collections.Generic;
using System.Text;

namespace PetMonitoring.Temperature.Application.DTOs
{
    public record TemperatureRecordDTO
    {
        public Guid Id { get; set; }
        public Guid DeviceId { get; set; }
        public DateTime CreatedDate { get; set; }
        public decimal CelsiusValue { get; set; }
    }
}
