using MediatR;
using PetMonitoring.DeviceManagement.Application.Results;

namespace PetMonitoring.DeviceManagement.Application.Commands.UpdateDeviceCommand;

public sealed record UpdateDeviceCommand
(
    string? SerialNumber,
    Guid DeviceId,
    string Name,
    string PetName
) : IRequest<DeviceOperationResult>;
