using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetMonitoring.DeviceManagement.Application.Interfaces;
using PetMonitoring.DeviceManagement.Domain.Entities;

namespace PetMonitoring.DeviceManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceController : ControllerBase
    {
        private readonly IDeviceRepository _repository;

        public DeviceController(IDeviceRepository repository)
        {
            _repository = repository;
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] DeviceRecord record)
        {
            await _repository.AddAsync(record);
            return Ok();
        }

        [HttpGet("{petId}")]
        public async Task<IActionResult> GetByPet(Guid petId)
        {
            var data = await _repository.GetByPetIdAsync(petId);
            return Ok(data);
        }
    }
}
