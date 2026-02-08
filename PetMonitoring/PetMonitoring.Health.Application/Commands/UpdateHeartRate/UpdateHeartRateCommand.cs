using MediatR;
using System.Net;

namespace PetMonitoring.Health.Application.Commands.UpdateHeartRate;

public sealed record UpdateHeartRateCommand
(
    Guid Id,
    Guid PetId,
    Guid DeviceId,
    int Bpm
) : IRequest<Unit>;
