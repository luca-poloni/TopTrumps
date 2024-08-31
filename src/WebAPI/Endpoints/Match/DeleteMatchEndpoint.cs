using Application.UseCases.Match.Commands.DeleteMatch;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace WebAPI.Endpoints.Match
{
    public class DeleteMatchEndpoint(IMediator mediator) : EndpointBaseAsync.WithRequest<DeleteMatchRequest>.WithoutResult
    {
        [HttpDelete("matches/delete")]
        [SwaggerOperation(OperationId = "Matches.Delete", Tags = ["Matches"])]
        public override async Task HandleAsync([FromQuery] DeleteMatchRequest request, CancellationToken cancellationToken = default)
        {
            await mediator.Send(request, cancellationToken);
        }
    }
}
