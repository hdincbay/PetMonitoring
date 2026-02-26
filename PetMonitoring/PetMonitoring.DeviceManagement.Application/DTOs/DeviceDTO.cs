using System;
using System.Collections.Generic;
using System.Text;

namespace PetMonitoring.DeviceManagement.Application.DTOs
{
    public class DeviceDTO
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? PetName { get; set; }
        public string? SerialNumber { get; set; }
        public int BatteryPercentage { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
