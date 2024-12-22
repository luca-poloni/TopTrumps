using Application.UseCases.Round.Commands.UpdateRound;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace WebAPI.Endpoints.Round
{
    public class UpdateRoundEndpoint(IMediator mediator) : EndpointBaseAsync.WithRequest<UpdateRoundRequest>.WithActionResult<UpdateRoundResponse>
    {
        [HttpPut("rounds/update")]
        [SwaggerOperation(OperationId = "Rounds.Update", Tags = ["Rounds"])]
        public override async Task<ActionResult<UpdateRoundResponse>> HandleAsync([FromBody] UpdateRoundRequest request, CancellationToken cancellationToken = default)
        {
            return await mediator.Send(request, cancellationToken);
        }
    }
}
