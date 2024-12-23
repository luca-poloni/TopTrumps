using Application.UseCases.Match.Commands.UpdateMatch;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace WebAPI.Endpoints.Match
{
    public class UpdateMatchEndpoint(IMediator mediator) : EndpointBaseAsync.WithRequest<UpdateMatchRequest>.WithActionResult<UpdateMatchResponse>
    {
        [Authorize(Roles = "Admin")]
        [HttpPut("matches/update")]
        [SwaggerOperation(OperationId = "Matches.Update", Tags = ["Matches"])]
        public override async Task<ActionResult<UpdateMatchResponse>> HandleAsync([FromBody] UpdateMatchRequest request, CancellationToken cancellationToken = default)
        {
            return await mediator.Send(request, cancellationToken);
        }
    }
}
