using Application.UseCases.Match.Queries.GetMatchById;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace WebAPI.Endpoints.Match
{
    public class GetMatchByIdEndpoint(IMediator mediator) : EndpointBaseAsync.WithRequest<GetMatchByIdRequest>.WithActionResult<GetMatchByIdResponse>
    {
        [Authorize(Roles = "User")]
        [HttpGet("matches/getById")]
        [SwaggerOperation(OperationId = "Matches.GetById", Tags = ["Matches"])]
        public override async Task<ActionResult<GetMatchByIdResponse>> HandleAsync([FromQuery] GetMatchByIdRequest request, CancellationToken cancellationToken = default)
        {
            return await mediator.Send(request, cancellationToken);
        }
    }
}
