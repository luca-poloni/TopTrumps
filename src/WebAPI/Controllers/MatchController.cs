using Application.UseCases.Match.Commands;
using Application.UseCases.Match.Queries;
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
        public async Task<ActionResult<CreateMatchResponse>> Create([FromBody] CreateMatchRequest request)
        {
            return await _mediator.Send(request);
        }

        [Route("Start")]
        [HttpPut]
        public async Task<ActionResult<StartMatchResponse>> Start([FromBody] StartMatchRequest request)
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
