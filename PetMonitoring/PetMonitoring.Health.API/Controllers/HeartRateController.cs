using MediatR;
using Microsoft.AspNetCore.Mvc;
using PetMonitoring.Health.API.Mappers;
using PetMonitoring.Health.Application.Commands.AddHeartRate;
using PetMonitoring.Health.Application.Queries;

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
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] AddHeartRateCommand record)
        {
            var result = await _mediator.Send(record);
            return result.ToActionResult(this);
        }
        [HttpGet("GetByDevice")]
        public async Task<IActionResult> GetByDevice([FromQuery] GetHeartRatesQuery record)
        {
            var result = await _mediator.Send(record);
            return result.ToHealthListResult(this);
        }
    }
}
