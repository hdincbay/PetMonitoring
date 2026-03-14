using MediatR;
using PetMonitoring.Temperature.Application.Results;

namespace PetMonitoring.Temperature.Application.Commands.AddTemperature;

public sealed record AddTemperatureCommand
(
    string DeviceSerialNumber,
    decimal CelsiusValue
) : IRequest<TemperatureOperationResult>;
