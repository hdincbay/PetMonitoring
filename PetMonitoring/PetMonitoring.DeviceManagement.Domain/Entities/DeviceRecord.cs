using System;
using System.Collections.Generic;
using System.Text;

namespace PetMonitoring.DeviceManagement.Domain.Entities
{
    public class DeviceRecord
    {
        public Guid Id { get; private set; }
        public Guid PetId { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public int BatteryPercentage { get; private set; }
        public DeviceRecord()
        {

        }
        public DeviceRecord(Guid petId, int batteryPercentage)
        {
            CreatedDate = DateTime.Now;
            BatteryPercentage = batteryPercentage;
            PetId = petId;
        }
    }
}
