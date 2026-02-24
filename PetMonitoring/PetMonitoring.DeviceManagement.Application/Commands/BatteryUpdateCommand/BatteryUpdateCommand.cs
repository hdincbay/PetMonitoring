using MediatR;

namespace PetMonitoring.DeviceManagement.Application.Commands.BatteryUpdateCommand;

public sealed record BatteryUpdateCommand
(
    Guid DeviceId,
    int BatteryPercentage
) : IRequest<Unit>;
