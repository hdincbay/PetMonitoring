using MediatR;

namespace PetMonitoring.DeviceManagement.Application.Commands.AddDeviceCommand;

public sealed record CreateDeviceCommand
(
    string Name
) : IRequest<Unit>;
