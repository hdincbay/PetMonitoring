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
        public DateTime CreatedDate { get; set; }
        private HeartRateRecord(){}
        public static HeartRateRecord Create(Guid petId, Guid deviceId, int bpm)
        {
            return new HeartRateRecord
            {
                PetId = petId,
                DeviceId = deviceId,
                Bpm = bpm,
                CreatedDate = DateTime.Now
            };
        }
        public void UpdateBpm(int bpm)
        {
            Bpm = bpm;
        }
    }
}
