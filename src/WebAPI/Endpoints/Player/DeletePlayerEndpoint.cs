using Application.UseCases.Player.Commands.DeletePlayer;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace WebAPI.Endpoints.Player
{
    public class DeletePlayerEndpoint(IMediator mediator) : EndpointBaseAsync.WithRequest<DeletePlayerRequest>.WithoutResult
    {
        [Authorize(Roles = "User")]
        [HttpDelete("players/delete")]
        [SwaggerOperation(OperationId = "Players.Delete", Tags = ["Players"])]
        public override async Task HandleAsync([FromQuery] DeletePlayerRequest request, CancellationToken cancellationToken = default)
        {
            await mediator.Send(request, cancellationToken);
        }
    }
}
