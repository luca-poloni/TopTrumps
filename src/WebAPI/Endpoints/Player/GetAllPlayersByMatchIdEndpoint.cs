using Application.UseCases.Player.Queries.GetAllPlayersByMatchId;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace WebAPI.Endpoints.Player
{
    public class GetAllPlayersByMatchIdEndpoint(IMediator mediator) : EndpointBaseAsync.WithRequest<GetAllPlayersByMatchIdRequest>.WithActionResult<IEnumerable<GetAllPlayersByMatchIdResponse>>
    {
        [Authorize(Roles = "User")]
        [HttpGet("players/getAllByMatchId")]
        [SwaggerOperation(OperationId = "Players.GetAllByMatchId", Tags = ["Players"])]
        public override async Task<ActionResult<IEnumerable<GetAllPlayersByMatchIdResponse>>> HandleAsync([FromQuery] GetAllPlayersByMatchIdRequest request, CancellationToken cancellationToken = default)
        {
            return Ok(await mediator.Send(request, cancellationToken));
        }
    }
}
