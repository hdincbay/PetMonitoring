using MediatR;
using PetMonitoring.Movement.Application.Results;
using PetMonitoring.Movement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetMonitoring.Movement.Application.Queries
{
    public sealed record GetMovementQuery(string DeviceSerialNumber) : IRequest<MovementOperationResult>
    {

    }
}
