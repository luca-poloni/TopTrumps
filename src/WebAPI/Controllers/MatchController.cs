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
        public async Task<ActionResult<PlayMatchCommandResponse>> Play([FromQuery] PlayMatchCommandRequest request)
        {
            return await _mediator.Send(request);
        }

        [Route("Move")]
        [HttpPost]
        public async Task<ActionResult<MoveMatchCommandResponse>> Move([FromQuery] MoveMatchCommandRequest request)
        {
            return await _mediator.Send(request);
        }

        [Route("GetById")]
        [HttpGet]
        public async Task<ActionResult<GetMatchByIdQueryResponse>> GetById([FromQuery] GetMatchByIdQueryRequest request)
        {
            return await _mediator.Send(request);
        }
    }
}
