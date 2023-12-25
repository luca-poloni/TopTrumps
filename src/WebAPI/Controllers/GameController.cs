using Application.UseCases.Game.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("Game")]
    [ApiController]
    public class GameController(IMediator mediator)
    {
        private readonly IMediator _mediator = mediator;

        [Route("Create")]
        [HttpPost]
        public async Task<ActionResult<CreateGameResponse>> Create([FromQuery] CreateGameRequest request)
        {
            return await _mediator.Send(request);
        }
    }
}
