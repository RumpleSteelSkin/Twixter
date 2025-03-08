using MediatR;
using Microsoft.AspNetCore.Mvc;
using TwixterR.Application.Features.Authentications.Login.Commands;
using TwixterR.Application.Features.Authentications.Register.Commands;

namespace TwixterR.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController(IMediator mediator) : ControllerBase
    {
        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterCommand command)
        {
            return Ok(await mediator.Send(command));
        }
        
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginCommand command)
        {
            return Ok(await mediator.Send(command));
        }
    }
}
