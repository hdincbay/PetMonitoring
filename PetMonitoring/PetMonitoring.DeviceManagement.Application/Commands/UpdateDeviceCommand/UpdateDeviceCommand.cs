using MediatR;

namespace PetMonitoring.DeviceManagement.Application.Commands.UpdateDeviceCommand;

public sealed record UpdateDeviceCommand
(
    Guid DeviceId,
    int BatteryPercentage
) : IRequest<Unit>;
