using Application.Handlers.Match.Commands.CreateMatch;
using Application.Handlers.Match.Commands.UpdateMatch;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("Match")]
    [ApiController]
    public class MatchController(IMediator mediator)
    {
        private readonly IMediator _mediator = mediator;

        [Route("Create")]
        [HttpPost]
        public async Task<ActionResult<CreateMatchCommandResponse>> Create([FromQuery] CreateMatchCommandRequest request)
        {
            return await _mediator.Send(request);
        }

        [Route("Update")]
        [HttpPost]
        public async Task<ActionResult<UpdateMatchCommandResponse>> Update([FromQuery] UpdateMatchCommandRequest request)
        {
            return await _mediator.Send(request);
        }
    }
}
