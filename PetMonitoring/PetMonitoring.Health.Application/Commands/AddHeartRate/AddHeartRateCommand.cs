using MediatR;
using System.Net;

namespace PetMonitoring.Health.Application.Commands.AddHeartRate;

public sealed record AddHeartRateCommand
(
    string DeviceSerialNumber,
    int Bpm
) : IRequest<Unit>;
