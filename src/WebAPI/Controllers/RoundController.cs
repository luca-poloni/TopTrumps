using Application.UseCases.Round.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("Round")]
    [ApiController]
    public class RoundController(IMediator mediator)
    {
        private readonly IMediator _mediator = mediator;

        [Route("Create")]
        [HttpPost]
        public async Task<ActionResult<CreateRoundResponse>> Create([FromBody] CreateRoundRequest request)
        {
            return await _mediator.Send(request);
        }

        [Route("TakeCard")]
        [HttpPut]
        public async Task<ActionResult<Unit>> TakeCard([FromBody] TakeCardRoundRequest request)
        {
            return await _mediator.Send(request);
        }

        [Route("Play")]
        [HttpPut]
        public async Task<ActionResult<PlayRoundResponse>> Play([FromBody] PlayRoundRequest request)
        {
            return await _mediator.Send(request);
        }
    }
}
