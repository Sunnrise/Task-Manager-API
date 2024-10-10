using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagerAPI.Application.Features.Duties.Commands.AddDuty;
using TaskManagerAPI.Application.Features.Duties.Commands.DeleteDuty;
using TaskManagerAPI.Application.Features.Duties.Commands.UpdateDuty;
using TaskManagerAPI.Application.Features.Duties.Commands.UpdateDutyStatus;
using TaskManagerAPI.Application.Features.Duties.Queries.GetDuties;

namespace TaskManagerAPI.API.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    [Authorize(AuthenticationSchemes="Admin")]
    public class DutyController : ControllerBase
    {
        private readonly IMediator mediator;

        public DutyController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AddDuty([FromBody] CreateDutyCommandRequest request)
        {
            var response = await mediator.Send(request);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDuty([FromBody] UpdateDutyCommandRequest request)
        {
            var response = await mediator.Send(request);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteDuty([FromQuery] DeleteDutyCommandRequest request)
        {
            var response = await mediator.Send(request);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDuties([FromQuery] GetAllDutiesByIdQueryRequest request)
        {
            var response = await mediator.Send(request);
            return Ok(response);
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateDutyStatus([FromQuery] UpdateDutyStatusCommandRequest request)
        {
            var response = await mediator.Send(request);
            return Ok(response);
        }
    }
}
