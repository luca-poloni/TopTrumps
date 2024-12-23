using Application.UseCases.Round.Queries.GetAllRoundsByMatchId;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace WebAPI.Endpoints.Round
{
    public class GetAllRoundsByMatchIdEndpoint(IMediator mediator) : EndpointBaseAsync.WithRequest<GetAllRoundsByMatchIdRequest>.WithActionResult<IEnumerable<GetAllRoundsByMatchIdResponse>>
    {
        [Authorize(Roles = "Admin")]
        [HttpGet("rounds/getAllRoundsByMatchId")]
        [SwaggerOperation(OperationId = "Rounds.GetAllRoundsByMatchId", Tags = ["Rounds"])]
        public override async Task<ActionResult<IEnumerable<GetAllRoundsByMatchIdResponse>>> HandleAsync([FromQuery] GetAllRoundsByMatchIdRequest request, CancellationToken cancellationToken = default)
        {
            return Ok(await mediator.Send(request, cancellationToken));
        }
    }
}
