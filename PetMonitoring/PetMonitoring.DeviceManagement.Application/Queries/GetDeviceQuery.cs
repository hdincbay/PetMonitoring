using MediatR;
using PetMonitoring.DeviceManagement.Application.DTOs;
using PetMonitoring.DeviceManagement.Application.Results;
using PetMonitoring.DeviceManagement.Domain.Entities;

namespace PetMonitoring.DeviceManagement.Application.Queries
{
    public sealed record GetDeviceQuery : IRequest<DeviceOperationResult>
    {
        public string? SerialNumber { get; set; }
        public Guid DeviceId { get; set; }
    }   
}
