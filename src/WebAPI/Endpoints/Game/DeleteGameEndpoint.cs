using Application.UseCases.Game.Commands.DeleteGame;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace WebAPI.Endpoints.Game
{
    public class DeleteGameEndpoint(IMediator mediator) : EndpointBaseAsync.WithRequest<DeleteGameRequest>.WithoutResult
    {
        private readonly IMediator _mediator = mediator;

        [HttpDelete("games/delete")]
        [SwaggerOperation(OperationId = "Games.Delete", Tags = ["Games"])]
        public override async Task HandleAsync([FromQuery] DeleteGameRequest request, CancellationToken cancellationToken = default)
        {
            await _mediator.Send(request, cancellationToken);
        }
    }
}
