using Application.UseCases.Round.Actions.PlayRound;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace WebAPI.Endpoints.Round
{
    public class PlayRoundEndpoint(IMediator mediator) : EndpointBaseAsync.WithRequest<PlayRoundRequest>.WithActionResult<PlayRoundResponse>
    {
        [HttpPost("rounds/play")]
        [SwaggerOperation(OperationId = "Rounds.Play", Tags = ["Rounds"])]
        public override async Task<ActionResult<PlayRoundResponse>> HandleAsync(PlayRoundRequest request, CancellationToken cancellationToken = default)
        {
            return await mediator.Send(request, cancellationToken);
        }
    }
}
