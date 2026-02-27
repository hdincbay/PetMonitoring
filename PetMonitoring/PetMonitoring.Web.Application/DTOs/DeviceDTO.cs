using System;
using System.Collections.Generic;
using System.Text;

namespace PetMonitoring.Web.Application.DTOs
{
    public record DeviceDTO
    {
        public string? ID { get; set; }
        public string? SerialNo { get; set; }
        public string? Name { get; set; }
        public string? PetName { get; set; }
    }
}
