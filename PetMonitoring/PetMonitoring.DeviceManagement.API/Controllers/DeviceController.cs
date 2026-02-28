using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetMonitoring.DeviceManagement.Application.Commands.CreateDeviceCommand;
using PetMonitoring.DeviceManagement.Application.Commands.BatteryUpdateCommand;
using PetMonitoring.DeviceManagement.Application.Queries;
using PetMonitoring.DeviceManagement.Application.Commands.UpdateDeviceCommand;
using PetMonitoring.DeviceManagement.API.Mappers;

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
            var result = await _mediator.Send(record);
            return result.ToActionResult(this);
        }
        [HttpPatch("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateDeviceCommand record)
        {
            var result = await _mediator.Send(record);
            return result.ToActionResult(this);
        }
        [HttpPut("BatteryUpdate")]
        public async Task<IActionResult> BatteryUpdate([FromBody] BatteryUpdateCommand record)
        {
            var result = await _mediator.Send(record);
            return result.ToActionResult(this);
        }
        [HttpGet("GetByDeviceId")]
        public async Task<IActionResult> GetByDeviceId([FromQuery] Guid deviceId)
        {
            var result = await _mediator.Send(new GetDeviceQuery() { DeviceId = deviceId });
            return result.ToDeviceResult(this);
        }
        [HttpGet("GetAllDevices")]
        public async Task<IActionResult> GetAllDevices()
        {
            var result = await _mediator.Send(new GetDevicesQuery());
            return result.ToDeviceListResult(this);
        }
    }
}
