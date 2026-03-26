using System;
using System.Collections.Generic;
using System.Text;

namespace PetMonitoring.Web.Application.DTOs.Device
{
    public record DeviceResponseDTO
    {
        public DeviceDTO? Device { get; }
        public List<DeviceDTO?> DeviceList { get; } = new List<DeviceDTO?>();
        public string? Message { get; }
        public int Status { get; }
    }
}
