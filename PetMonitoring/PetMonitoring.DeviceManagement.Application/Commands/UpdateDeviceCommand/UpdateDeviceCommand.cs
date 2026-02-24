using MediatR;

namespace PetMonitoring.DeviceManagement.Application.Commands.UpdateDeviceCommand;

public sealed record UpdateDeviceCommand
(
    Guid DeviceId,
    string Name,
    string PetName
) : IRequest<Unit>;
