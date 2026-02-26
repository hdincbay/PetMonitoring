using MediatR;
using PetMonitoring.DeviceManagement.Application.DTOs;

namespace PetMonitoring.DeviceManagement.Application.Queries
{
    public class GetDevicesQuery : IRequest<IEnumerable<DeviceRecordDTO>>
    {
    }
}
