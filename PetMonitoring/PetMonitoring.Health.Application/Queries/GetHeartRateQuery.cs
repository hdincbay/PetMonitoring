using MediatR;
using PetMonitoring.Health.Application.Results;
using PetMonitoring.Health.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetMonitoring.Health.Application.Queries
{
    public sealed record GetHeartRateQuery(string DeviceSerialNumber) : IRequest<HealthOperationResult>
    {

    }
}
