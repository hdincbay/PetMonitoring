using MediatR;
using System.Net;

namespace PetMonitoring.Health.Application.Commands.AddHeartRate;

public sealed record AddHeartRateCommand
(
    Guid DeviceId,
    int Bpm
) : IRequest<Unit>;
