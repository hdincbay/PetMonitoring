using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetMonitoring.Health.Application.Interfaces;
using PetMonitoring.Health.Domain.Entities;

namespace PetMonitoring.Health.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeartRateController : ControllerBase
    {
        private readonly IHeartRateRepository _repository;

        public HeartRateController(IHeartRateRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] HeartRateRecord record)
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
