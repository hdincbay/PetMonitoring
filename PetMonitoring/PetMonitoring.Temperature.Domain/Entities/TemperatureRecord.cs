using System;
using System.Collections.Generic;
using System.Text;

namespace PetMonitoring.Temperature.Domain.Entities
{
    public class TemperatureRecord
    {
        public Guid Id { get; private set; }
        public string? DeviceSerialNumber { get; private set; }
        public DateTime CreatedDate { get; set; }
        public decimal CelsiusValue { get; private set; }
        public TemperatureRecord()
        {
            
        }
        public static TemperatureRecord Create(string deviceSerialNumber, decimal celsiusValue)
        {
            return new TemperatureRecord
            {
                CelsiusValue = celsiusValue,
                DeviceSerialNumber = deviceSerialNumber,
                CreatedDate = DateTime.Now
            };
        }
    }
}
