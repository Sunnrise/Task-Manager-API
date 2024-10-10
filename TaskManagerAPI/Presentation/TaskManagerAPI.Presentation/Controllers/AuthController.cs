using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagerAPI.Application.Features.User.Commands.LoginUser;
using TaskManagerAPI.Application.Features.User.Commands.RefreshTokenLogin;

namespace TaskManagerAPI.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        readonly IMediator mediator;

        public AuthController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Login([FromBody] LoginUserCommandRequest request)
        {
            LoginUserCommandResponse response = await mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> RefreshTokenLogin([FromQuery]RefreshTokenLoginCommandRequest request)
        {
            RefreshTokenLoginCommandResponse response = await mediator.Send(request);
            return Ok(response);
        }
    }
}
