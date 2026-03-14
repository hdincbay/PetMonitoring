using System;
using System.Collections.Generic;
using System.Text;

namespace PetMonitoring.Temperature.Application.DTOs
{
    public record TemperatureRecordDTO
    {
        public Guid Id { get; private set; }
        public Guid DeviceId { get; private set; }
        public DateTime CreatedDate { get; set; }
        public decimal CelsiusValue { get; private set; }
    }
}
