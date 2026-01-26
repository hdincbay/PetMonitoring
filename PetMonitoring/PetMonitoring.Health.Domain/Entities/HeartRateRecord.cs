using System;
using System.Collections.Generic;
using System.Text;

namespace PetMonitoring.Health.Domain.Entities
{
    public class HeartRateRecord
    {
        public Guid Id { get; private set; }
        public Guid PetId { get; private set; }
        public Guid DeviceId { get; private set; }
        public int Bpm { get; private set; }
        public DateTime MeasuredAt { get; set; }
        public HeartRateRecord()
        {
            
        }
        public HeartRateRecord(Guid petId, Guid deviceId, int bpm, DateTime measuredAt)
        {
            if (bpm < 30 || bpm > 300)
                throw new ArgumentException("Invalid BPM value!");
            PetId = petId;
            DeviceId = deviceId;
            Bpm = bpm;
            MeasuredAt = measuredAt;
        }
    }
}
