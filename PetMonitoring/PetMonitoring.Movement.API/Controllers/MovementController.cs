using Microsoft.AspNetCore.Mvc;
using PetMonitoring.Movement.Application.Commands;
using PetMonitoring.Movement.Application.Interfaces;

namespace PetMonitoring.Movement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovementController : ControllerBase
    {
        private readonly IMovementService _service;

        public MovementController(IMovementService service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateMovementCommand record)
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
