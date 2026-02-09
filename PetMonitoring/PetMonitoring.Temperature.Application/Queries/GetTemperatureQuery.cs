using MediatR;
using PetMonitoring.Temperature.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetMonitoring.Temperature.Application.Queries
{
    public sealed record GetTemperatureQuery(Guid DeviceId) : IRequest<IEnumerable<TemperatureRecord>>
    {

    }
}
