using PetMonitoring.DeviceManagement.Application.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetMonitoring.DeviceManagement.Application.Queries
{
    public record QueryResult
    {
        public string? Message { get; set; }
        public RequestStatus Status { get; set; }
    }
}
