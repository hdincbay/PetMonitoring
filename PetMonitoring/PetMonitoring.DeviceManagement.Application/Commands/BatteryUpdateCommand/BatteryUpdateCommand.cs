using MediatR;
using PetMonitoring.DeviceManagement.Application.Results;

namespace PetMonitoring.DeviceManagement.Application.Commands.BatteryUpdateCommand;

public sealed record BatteryUpdateCommand
(
    string SerialNumber,
    Guid DeviceId,
    int BatteryPercentage
) : IRequest<DeviceOperationResult>;
