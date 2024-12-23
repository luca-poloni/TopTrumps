using Application.UseCases.Player.Commands.UpdatePlayer;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace WebAPI.Endpoints.Player
{
    public class UpdatePlayerEndpoint(IMediator mediator) : EndpointBaseAsync.WithRequest<UpdatePlayerRequest>.WithActionResult<UpdatePlayerResponse>
    {
        [Authorize(Roles = "User")]
        [HttpPut("players/update")]
        [SwaggerOperation(OperationId = "Players.Update", Tags = ["Players"])]
        public override async Task<ActionResult<UpdatePlayerResponse>> HandleAsync([FromBody] UpdatePlayerRequest request, CancellationToken cancellationToken = default)
        {
            return await mediator.Send(request, cancellationToken);
        }
    }
}
