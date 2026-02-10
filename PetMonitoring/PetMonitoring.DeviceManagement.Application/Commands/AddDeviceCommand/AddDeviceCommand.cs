using MediatR;

namespace PetMonitoring.DeviceManagement.Application.Commands.AddDeviceCommand;

public sealed record AddDeviceCommand
(
    string Name
) : IRequest<Unit>;
