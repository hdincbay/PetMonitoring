using System;
using System.Collections.Generic;
using System.Text;

namespace PetMonitoring.DeviceManagement.Domain.Entities
{
    public class DeviceRecord
    {
        public Guid Id { get; private set; }
        public string? Name { get; private set; }
        public Guid PetId { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public int BatteryPercentage { get; private set; }
        public DeviceRecord()
        {

        }
        public static DeviceRecord Create(string name)
        {
            return new DeviceRecord
            {
                CreatedDate = DateTime.Now,
                Name = name
            };
        }
        public void UpdateBatteryPercentage(int batteryPercentage)
        {
            if (batteryPercentage < 0 || batteryPercentage > 100)
                throw new ArgumentOutOfRangeException(nameof(batteryPercentage));

            BatteryPercentage = batteryPercentage;
        }
    }
}
