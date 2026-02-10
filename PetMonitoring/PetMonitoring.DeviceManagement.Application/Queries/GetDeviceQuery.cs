using MediatR;
using PetMonitoring.DeviceManagement.Domain.Entities;

namespace PetMonitoring.DeviceManagement.Application.Queries
{
    public sealed record GetDeviceQuery : IRequest<DeviceRecord>
    {
        public Guid DeviceId { get; set; }
    }   
}
