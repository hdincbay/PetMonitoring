using MediatR;
using Microsoft.AspNetCore.Mvc;
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
            await _mediator.Send(record);
            return Ok();
        }
        [HttpGet("GetByDevice")]
        public async Task<IActionResult> GetByDevice([FromQuery] GetHeartRateQuery record)
        {
            var recordList = await _mediator.Send(record);
            return Ok(recordList);
        }
    }
}
