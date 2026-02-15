using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetMonitoring.DeviceManagement.Application.Commands.CreateDeviceCommand;
using PetMonitoring.DeviceManagement.Application.Commands.UpdateDeviceCommand;
using PetMonitoring.DeviceManagement.Application.Queries;

namespace PetMonitoring.DeviceManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DeviceController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CreateDeviceCommand record)
        {
            await _mediator.Send(record);
            return Ok();
        }
        [HttpPut("BatteryUpdate")]
        public async Task<IActionResult> BatteryUpdate([FromBody] UpdateDeviceCommand record)
        { 
            await _mediator.Send(record);
            return Ok();
        }
        [HttpGet("GetByDevice")]
        public async Task<IActionResult> GetByDevice([FromQuery] GetDeviceQuery record)
        {
            var data = await _mediator.Send(record);
            return Ok(data);
        }
    }
}
