using MediatR;

namespace PetMonitoring.DeviceManagement.Application.Commands.CreateDeviceCommand;

public sealed record CreateDeviceCommand
(
    string Name,
    string PetName
) : IRequest<Unit>;
