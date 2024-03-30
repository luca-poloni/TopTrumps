using Application.UseCases.Game.Commands.CreateGame;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Endpoints.Game
{
    public class CreateGameEndpoint(IMediator mediator) : EndpointBaseAsync.WithRequest<CreateGameRequest>.WithActionResult<CreateGameResponse>
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost("/game")]
        public override async Task<ActionResult<CreateGameResponse>> HandleAsync([FromBody] CreateGameRequest request, CancellationToken cancellationToken = default)
        {
            return await _mediator.Send(request, cancellationToken);
        }
    }
}
