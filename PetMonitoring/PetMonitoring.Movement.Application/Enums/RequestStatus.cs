using System;
using System.Collections.Generic;
using System.Text;

namespace PetMonitoring.Movement.Application.Enums
{
    public enum RequestStatus
    {
        Success = 0,
        ValidationError = 1,
        AlreadyExists = 2,
        Failed = 3,
        NotFound = 4
    }
}
