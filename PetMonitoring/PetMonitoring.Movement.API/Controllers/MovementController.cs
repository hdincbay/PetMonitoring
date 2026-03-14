using MediatR;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using PetMonitoring.Movement.API.Mappers;
using PetMonitoring.Movement.Application.Commands;
using PetMonitoring.Movement.Application.Commands.AddMovement;
using PetMonitoring.Movement.Application.Interfaces;
using PetMonitoring.Movement.Application.Queries;

namespace PetMonitoring.Movement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovementController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MovementController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddMovementCommand record)
        {
            var result = await _mediator.Send(record);
            return result.ToActionResult(this);
        }
        [HttpGet("GetByDevice")]
        public async Task<IActionResult> GetByDevice([FromQuery] GetMovementsQuery record)
        {
            var result = await _mediator.Send(record);
            return result.ToMovementListResult(this);
        }
    }
}
