using Microsoft.AspNetCore.Mvc;
using PetMonitoring.Movement.Application.Interfaces;
using PetMonitoring.Movement.Domain.Entities;

namespace PetMonitoring.Movement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovementController : ControllerBase
    {
        private readonly IMovementRepository _repository;

        public MovementController(IMovementRepository repository)
        {
            _repository = repository;
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] MovementRecord record)
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
