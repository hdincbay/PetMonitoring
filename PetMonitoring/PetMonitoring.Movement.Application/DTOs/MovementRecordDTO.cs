using PetMonitoring.Movement.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetMonitoring.Movement.Application.DTOs
{
    public record MovementRecordDTO
    {
        public Guid Id { get; private set; }
        public string? DeviceSerialNumber { get; private set; }
        public ActivityLevel ActivityLevel { get; private set; }
        public DateTime CreatedDate { get; set; }
    }
}
