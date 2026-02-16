using System;
using System.Collections.Generic;
using System.Text;

namespace PetMonitoring.Health.Domain.Entities
{
    public class HeartRateRecord
    {
        public Guid Id { get; private set; }
        public string? DeviceSerialNumber { get; private set; }
        public int Bpm { get; private set; }
        public DateTime CreatedDate { get; set; }
        private HeartRateRecord(){}
        public static HeartRateRecord Create(string deviceSerialNumber, int bpm)
        {
            return new HeartRateRecord
            {
                DeviceSerialNumber = deviceSerialNumber,
                Bpm = bpm,
                CreatedDate = DateTime.Now
            };
        }
    }
}
