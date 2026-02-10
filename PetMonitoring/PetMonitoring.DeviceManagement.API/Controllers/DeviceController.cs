using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetMonitoring.DeviceManagement.Application.Commands.AddDeviceCommand;
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
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] AddDeviceCommand record)
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
