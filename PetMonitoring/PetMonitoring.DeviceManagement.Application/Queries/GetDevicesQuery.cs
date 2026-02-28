using MediatR;
using PetMonitoring.DeviceManagement.Application.DTOs;
using PetMonitoring.DeviceManagement.Application.Results;

namespace PetMonitoring.DeviceManagement.Application.Queries
{
    public class GetDevicesQuery : IRequest<DeviceOperationResult>
    {
    }
}
