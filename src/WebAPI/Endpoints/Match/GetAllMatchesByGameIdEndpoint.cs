using Application.UseCases.Match.Queries.GetAllMatchesByGameId;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace WebAPI.Endpoints.Match
{
    public class GetAllMatchesByGameIdEndpoint(IMediator mediator) : EndpointBaseAsync.WithRequest<GetAllMatchesByGameIdRequest>.WithActionResult<IEnumerable<GetAllMatchesByGameIdResponse>>
    {
        [HttpGet("matches/getAllByGameId")]
        [SwaggerOperation(OperationId = "Matches.GetAllByGameId", Tags = ["Matches"])]
        public override async Task<ActionResult<IEnumerable<GetAllMatchesByGameIdResponse>>> HandleAsync([FromQuery] GetAllMatchesByGameIdRequest request, CancellationToken cancellationToken = default)
        {
            return Ok(await mediator.Send(request, cancellationToken));
        }
    }
}
