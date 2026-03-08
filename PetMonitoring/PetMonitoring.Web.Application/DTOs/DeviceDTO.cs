using System;
using System.Collections.Generic;
using System.Text;

namespace PetMonitoring.Web.Application.DTOs
{
    public record DeviceDTO
    {
        public Guid ID { get; set; }
        public string? SerialNumber { get; set; }
        public string? Name { get; set; }
        public string? PetName { get; set; }
    }
}
