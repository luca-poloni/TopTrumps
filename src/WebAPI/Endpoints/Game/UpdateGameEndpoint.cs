using Application.UseCases.Game.Commands.UpdateGame;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Endpoints.Game
{
    public class UpdateGameEndpoint(IMediator mediator) : EndpointBaseAsync.WithRequest<UpdateGameRequest>.WithActionResult<UpdateGameResponse>
    {
        private readonly IMediator _mediator = mediator;

        [HttpPut("/game")]
        public override async Task<ActionResult<UpdateGameResponse>> HandleAsync([FromBody] UpdateGameRequest request, CancellationToken cancellationToken = default)
        {
            return await _mediator.Send(request, cancellationToken);
        }
    }
}
