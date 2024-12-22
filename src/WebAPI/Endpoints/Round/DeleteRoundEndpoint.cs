using Application.UseCases.Round.Commands.DeleteRound;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace WebAPI.Endpoints.Round
{
    public class DeleteRoundEndpoint(IMediator mediator) : EndpointBaseAsync.WithRequest<DeleteRoundRequest>.WithoutResult
    {
        [HttpDelete("rounds/delete")]
        [SwaggerOperation(OperationId = "Rounds.Delete", Tags = ["Rounds"])]
        public override async Task HandleAsync([FromQuery] DeleteRoundRequest request, CancellationToken cancellationToken = default)
        {
            await mediator.Send(request, cancellationToken);
        }
    }
}
