using Application.UseCases.Match.Actions.PlayMatch;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace WebAPI.Endpoints.Match
{
    public class PlayMatchEndpoint(IMediator mediator) : EndpointBaseAsync.WithRequest<PlayMatchRequest>.WithoutResult
    {
        [Authorize(Roles = "User")]
        [HttpPost("matches/play")]
        [SwaggerOperation(OperationId = "Matches.Play", Tags = ["Matches"])]
        public override async Task HandleAsync(PlayMatchRequest request, CancellationToken cancellationToken = default)
        {
            await mediator.Send(request, cancellationToken);
        }
    }
}
