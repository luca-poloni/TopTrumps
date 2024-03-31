using Application.UseCases.Game.Commands.DeleteGame;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Endpoints.Game
{
    public class DeleteGameEndpoint(IMediator mediator) : EndpointBaseAsync.WithRequest<DeleteGameRequest>.WithoutResult
    {
        private readonly IMediator _mediator = mediator;

        [HttpDelete("/game")]
        public override async Task HandleAsync([FromQuery] DeleteGameRequest request, CancellationToken cancellationToken = default)
        {
            await _mediator.Send(request, cancellationToken);
        }
    }
}
