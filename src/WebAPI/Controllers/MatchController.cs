using Application.Handlers.Match.Commands.CreateMatch;
using Application.Handlers.Match.Commands.MoveMatch;
using Application.Handlers.Match.Commands.PlayMatch;
using Application.Handlers.Match.Queries.GetMatchById;
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
        public async Task<ActionResult<CreateMatchResponse>> Create([FromQuery] CreateMatchRequest request)
        {
            return await _mediator.Send(request);
        }

        [Route("Play")]
        [HttpPost]
        public async Task<ActionResult<PlayMatchResponse>> Play([FromQuery] PlayMatchRequest request)
        {
            return await _mediator.Send(request);
        }

        [Route("Move")]
        [HttpPost]
        public async Task<ActionResult<MoveMatchResponse>> Move([FromQuery] MoveMatchRequest request)
        {
            return await _mediator.Send(request);
        }

        [Route("GetById")]
        [HttpGet]
        public async Task<ActionResult<GetMatchByIdResponse>> GetById([FromQuery] GetMatchByIdRequest request)
        {
            return await _mediator.Send(request);
        }
    }
}
