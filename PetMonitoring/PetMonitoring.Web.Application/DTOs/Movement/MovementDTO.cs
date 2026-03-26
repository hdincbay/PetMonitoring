using PetMonitoring.Web.Application.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetMonitoring.Web.Application.DTOs.Movement
{
    public record MovementDTO
    {
        public ActivityLevel ActivityLevel { get; }
        public DateTime CreatedDate { get; }
    }
}
