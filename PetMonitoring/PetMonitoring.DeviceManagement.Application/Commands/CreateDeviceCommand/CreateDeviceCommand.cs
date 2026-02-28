using MediatR;

namespace PetMonitoring.DeviceManagement.Application.Commands.CreateDeviceCommand;

public sealed record CreateDeviceCommand
(
    string SerialNumber,
    string Name,
    string PetName
) : IRequest<Unit>;
