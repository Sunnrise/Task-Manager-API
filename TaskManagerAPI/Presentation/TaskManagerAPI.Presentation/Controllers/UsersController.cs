using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagerAPI.Application.Features.User.Commands.CreateUser;
using TaskManagerAPI.Application.Features.User.Commands.LoginUser;

namespace TaskManagerAPI.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        readonly IMediator mediator;

        public UsersController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult>Register(CreateUserCommandRequest request)
        {
            CreateUserCommandResponse response = await mediator.Send(request);
            return Ok(response);
        }
        
    }
}
