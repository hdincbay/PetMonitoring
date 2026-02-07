using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetMonitoring.Health.Application.Commands;
using PetMonitoring.Health.Application.Interfaces;

namespace PetMonitoring.Health.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeartRateController : ControllerBase
    {
        private readonly IHeartRateService _service;

        public HeartRateController(IHeartRateService service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateHeartRateCommand record)
        {
            await _service.AddAsync(record);
            return Ok();
        }

        [HttpGet("{petId}")]
        public async Task<IActionResult> GetByPet([FromRoute] Guid petId)
        {
            var data = await _service.GetByPetIdAsync(petId);
            return Ok(data);
        }
    }
}
