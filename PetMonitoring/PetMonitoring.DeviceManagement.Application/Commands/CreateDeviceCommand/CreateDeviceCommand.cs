using MediatR;
using PetMonitoring.DeviceManagement.Application.Results;

namespace PetMonitoring.DeviceManagement.Application.Commands.CreateDeviceCommand;

public sealed record CreateDeviceCommand
(
    string SerialNumber,
    string Name,
    string PetName
) : IRequest<DeviceOperationResult>;
