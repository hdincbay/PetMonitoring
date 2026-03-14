using System;
using System.Collections.Generic;
using System.Text;

namespace PetMonitoring.Health.Application.DTOs
{
    public record HeartRateRecordDTO
    {
        public Guid Id { get; private set; }
        public string? DeviceSerialNumber { get; private set; }
        public int Bpm { get; private set; }
        public DateTime CreatedDate { get; set; }
    }
}
