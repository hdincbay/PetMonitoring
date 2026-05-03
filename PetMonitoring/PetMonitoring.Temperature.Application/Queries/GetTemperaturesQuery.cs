using MediatR;
using PetMonitoring.Temperature.Application.Results;
using PetMonitoring.Temperature.Domain.Entities;

namespace PetMonitoring.Temperature.Application.Queries
{
    public sealed record GetTemperaturesQuery(string DeviceSerialNumber, int Take) : IRequest<TemperatureOperationResult>
    {
       
    }   
}
