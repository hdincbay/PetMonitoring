using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        private readonly IMediator _mdeiator;

        public TemperatureController(IMediator mediator)
        {
            _mdeiator = mediator;
        }
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] AddTemperatureCommand record)
        {
            await _mdeiator.Send(record);
            return Ok();
        }

        [HttpGet("GetByDevice")]
        public async Task<IActionResult> GetByDevice([FromRoute] GetTemperatureQuery record)
        {
            var recordList = await _mdeiator.Send(record);
            return Ok(recordList);
        }
    }
}
