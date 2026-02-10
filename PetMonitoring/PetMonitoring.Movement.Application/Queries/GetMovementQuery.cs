using MediatR;
using PetMonitoring.Movement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetMonitoring.Movement.Application.Queries
{
    public sealed record GetMovementQuery(Guid DeviceId) : IRequest<MovementRecord>
    {

    }
}
