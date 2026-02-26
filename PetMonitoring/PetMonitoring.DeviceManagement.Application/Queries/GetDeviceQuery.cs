using MediatR;
using PetMonitoring.DeviceManagement.Application.DTOs;
using PetMonitoring.DeviceManagement.Domain.Entities;

namespace PetMonitoring.DeviceManagement.Application.Queries
{
    public sealed record GetDeviceQuery : IRequest<DeviceRecordDTO>
    {
        public Guid DeviceId { get; set; }
    }   
}
