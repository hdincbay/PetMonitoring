using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetMonitoring.DeviceManagement.Application.Commands;
using PetMonitoring.DeviceManagement.Application.Interfaces;
using PetMonitoring.DeviceManagement.Domain.Entities;
using PetMonitoring.Health.Application.Interfaces;

namespace PetMonitoring.DeviceManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceController : ControllerBase
    {
        private readonly IDeviceService _service;

        public DeviceController(IDeviceService service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateDeviceCommand record)
        {
            await _service.AddAsync(record);
            return Ok();
        }

        [HttpGet("{petId}")]
        public async Task<IActionResult> GetByPet(Guid petId)
        {
            var data = await _service.GetByPetIdAsync(petId);
            return Ok();
        }
    }
}
