using MediatR;
using PetMonitoring.DeviceManagement.Application.Results;

namespace PetMonitoring.DeviceManagement.Application.Commands.UpdateDeviceCommand;

public sealed record UpdateDeviceCommand
(
    string? SerialNumber,
    Guid ID,
    string Name,
    string PetName,
    bool IsDeleted,
    DateTime DeletedDate
) : IRequest<DeviceOperationResult>;
