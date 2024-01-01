using Application.UseCases.Player.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("Player")]
    [ApiController]
    public class PlayerController(IMediator mediator)
    {
        private readonly IMediator _mediator = mediator;

        [Route("Create")]
        [HttpPost]
        public async Task<ActionResult<CreatePlayerResponse>> Create([FromBody] CreatePlayerRequest request)
        {
            return await _mediator.Send(request);
        }
    }
}
