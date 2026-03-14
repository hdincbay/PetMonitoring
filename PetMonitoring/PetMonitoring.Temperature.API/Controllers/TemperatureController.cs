using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetMonitoring.Temperature.API.Mappers;
using PetMonitoring.Temperature.Application.Commands.AddTemperature;
using PetMonitoring.Temperature.Application.Interfaces;
using PetMonitoring.Temperature.Application.Queries;
using PetMonitoring.Temperature.Domain.Entities;

namespace PetMonitoring.Temperature.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemperatureController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TemperatureController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] AddTemperatureCommand record)
        {
            var result = await _mediator.Send(record);
            return result.ToActionResult(this);
        }

        [HttpGet("GetByDevice")]
        public async Task<IActionResult> GetByDevice([FromQuery] GetTemperaturesQuery record)
        {
            var result = await _mediator.Send(record);
            return result.ToTemperatureListResult(this);
        }
    }
}
