using MediatR;
using PetMonitoring.Temperature.Domain.Entities;

namespace PetMonitoring.Temperature.Application.Queries
{
    public sealed record GetTemperatureQuery : IRequest<TemperatureRecord>
    {
        public Guid DeviceId { get; set; }
    }   
}
