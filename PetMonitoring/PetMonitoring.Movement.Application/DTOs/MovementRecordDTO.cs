using PetMonitoring.Movement.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetMonitoring.Movement.Application.DTOs
{
    public class MovementRecordDTO
    {
        public Guid Id { get; private set; }
        public string? DeviceSerialNumber { get; private set; }
        public int StepCount { get; private set; }
        public double DistanceInMeters { get; private set; }
        public ActivityLevel ActivityLevel { get; private set; }

        public int ActiveMinutes { get; private set; }
        public int InactiveMinutes { get; private set; }
        public DateTime CreatedDate { get; set; }
    }
}
