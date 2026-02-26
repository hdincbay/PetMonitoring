using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetMonitoring.DeviceManagement.Application.Commands.CreateDeviceCommand;
using PetMonitoring.DeviceManagement.Application.Commands.BatteryUpdateCommand;
using PetMonitoring.DeviceManagement.Application.Queries;
using PetMonitoring.DeviceManagement.Application.Commands.UpdateDeviceCommand;

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
        [HttpPatch("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateDeviceCommand record)
        {
            await _mediator.Send(record);
            return Ok();
        }
        [HttpPut("BatteryUpdate")]
        public async Task<IActionResult> BatteryUpdate([FromBody] BatteryUpdateCommand record)
        { 
            await _mediator.Send(record);
            return Ok();
        }
        [HttpGet("GetByDeviceId")]
        public async Task<IActionResult> GetByDeviceId([FromQuery] Guid deviceId)
        {
            var data = await _mediator.Send(new GetDeviceQuery() { DeviceId = deviceId });
            return Ok(data);
        }
        [HttpGet("GetAllDevices")]
        public async Task<IActionResult> GetAllDevices()
        {
            var data = await _mediator.Send(new GetDevicesQuery());
            return Ok(data);
        }
    }
}
