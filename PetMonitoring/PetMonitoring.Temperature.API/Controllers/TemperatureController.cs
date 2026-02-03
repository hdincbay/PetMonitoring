using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetMonitoring.Temperature.Application.Interfaces;
using PetMonitoring.Temperature.Domain.Entities;

namespace PetMonitoring.Temperature.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemperatureController : ControllerBase
    {
        private readonly ITemperatureRepository _repository;

        public TemperatureController(ITemperatureRepository repository)
        {
            _repository = repository;
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] TemperatureRecord record)
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
