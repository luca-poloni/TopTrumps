using Application.UseCases.Match.Commands.CreateMatch;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace WebAPI.Endpoints.Match
{
    public class CreateMatchEndpoint(IMediator mediator) : EndpointBaseAsync.WithRequest<CreateMatchRequest>.WithActionResult<CreateMatchResponse>
    {
        [HttpPost("matches/create")]
        [SwaggerOperation(OperationId = "Matches.Create", Tags = ["Matches"])]
        public override async Task<ActionResult<CreateMatchResponse>> HandleAsync([FromBody] CreateMatchRequest request, CancellationToken cancellationToken = default)
        {
            return await mediator.Send(request, cancellationToken);
        }
    }
}
