using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetMonitoring.Health.Application.Commands.AddHeartRate;
using PetMonitoring.Health.Application.Interfaces;

namespace PetMonitoring.Health.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeartRateController : ControllerBase
    {
        private readonly IMediator _mediator;

        public HeartRateController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddHeartRateCommand record)
        {
            await _mediator.Send(record);
            return Ok();
        }

        [HttpGet("{petId}")]
        public async Task<IActionResult> GetByPet([FromRoute] Guid petId)
        {
            return Ok();
        }
    }
}
