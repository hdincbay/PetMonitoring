using System;
using System.Collections.Generic;
using System.Text;

namespace PetMonitoring.Web.Application.DTOs
{
    public record DeviceResponseDTO
    {
        public DeviceDTO? Device { get; set; }
        public List<DeviceDTO?> DeviceList { get; set; } = new List<DeviceDTO?>();
        public string? Message { get; set; }
        public int Status { get; set; }
    }
}
