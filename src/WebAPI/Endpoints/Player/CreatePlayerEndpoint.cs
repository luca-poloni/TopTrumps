using Application.UseCases.Player.Commands.CreatePlayer;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace WebAPI.Endpoints.Player
{
    public class CreatePlayerEndpoint(IMediator mediator) : EndpointBaseAsync.WithRequest<CreatePlayerRequest>.WithActionResult<CreatePlayerResponse>
    {
        [HttpPost("players/create")]
        [SwaggerOperation(OperationId = "Players.Create", Tags = ["Players"])]
        public override async Task<ActionResult<CreatePlayerResponse>> HandleAsync([FromBody] CreatePlayerRequest request, CancellationToken cancellationToken = default)
        {
            return await mediator.Send(request, cancellationToken);
        }
    }
}
