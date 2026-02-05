using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetMonitoring.Health.Application.Interfaces;
using PetMonitoring.Temperature.Application.Interfaces;
using PetMonitoring.Temperature.Domain.Entities;

namespace PetMonitoring.Temperature.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemperatureController : ControllerBase
    {
        private readonly ITemperatureService _service;

        public TemperatureController(ITemperatureService service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] TemperatureRecord record)
        {

            //await _service.HandleAsync(record);
            return Ok();
        }

        [HttpGet("{petId}")]
        public async Task<IActionResult> GetByPet(Guid petId)
        {
            //var data = await _repository.GetByPetIdAsync(petId);
            return Ok();
        }
    }
}
