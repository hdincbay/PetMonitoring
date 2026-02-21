using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetMonitoring.Auth.Application.Commands.Login;
using PetMonitoring.Auth.Application.Commands.Register;

namespace PetMonitoring.Auth.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginCommand record)
        {
            var result = await _mediator.Send(record);
            return Ok(result);
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterCommand record)
        {
            var result = await _mediator.Send(record);
            return Ok(result);
        }
    }
}
