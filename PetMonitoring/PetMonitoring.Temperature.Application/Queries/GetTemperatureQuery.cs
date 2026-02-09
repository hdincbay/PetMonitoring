using MediatR;
using PetMonitoring.Temperature.Domain.Entities;

namespace PetMonitoring.Temperature.Application.Queries
{
    public sealed record GetTemperatureQuery : IRequest<IEnumerable<TemperatureRecord>>
    {
        public Guid DeviceId { get; set; }
    }   
}
