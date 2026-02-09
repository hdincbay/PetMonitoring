using System;
using System.Collections.Generic;
using System.Text;

namespace PetMonitoring.Temperature.Domain.Entities
{
    public class TemperatureRecord
    {
        public Guid Id { get; private set; }
        public Guid PetId { get; private set; }
        public Guid DeviceId { get; private set; }
        public DateTime CreatedDate { get; set; }
        public decimal CelsiusValue { get; private set; }
        public TemperatureRecord()
        {
            
        }
        public static TemperatureRecord Create(Guid petId, Guid deviceId, decimal celsiusValue)
        {
            return new TemperatureRecord
            {
                CelsiusValue = celsiusValue,
                PetId = petId,
                DeviceId = deviceId,
                CreatedDate = DateTime.Now
            };
        }
    }
}
