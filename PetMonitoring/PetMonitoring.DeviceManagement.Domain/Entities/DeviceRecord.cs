using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace PetMonitoring.DeviceManagement.Domain.Entities
{
    public class DeviceRecord
    {
        public Guid Id { get; private set; }
        public string? Name { get; private set; }
        public string? PetName { get; private set; }
        public string? SerialNumber { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public int BatteryPercentage { get; private set; }
        public DeviceRecord()
        {

        }
        public static DeviceRecord Create(string name, string petName)
        {
            return new DeviceRecord
            {
                CreatedDate = DateTime.Now,
                Name = name,
                PetName = petName
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
