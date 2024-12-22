using Application.UseCases.Round.Commands.CreateRound;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace WebAPI.Endpoints.Round
{
    public class CreateRoundEndpoint(IMediator mediator) : EndpointBaseAsync.WithRequest<CreateRoundRequest>.WithActionResult<CreateRoundResponse>
    {
        [HttpPost("rounds/create")]
        [SwaggerOperation(OperationId = "Rounds.Create", Tags = ["Rounds"])]
        public override async Task<ActionResult<CreateRoundResponse>> HandleAsync([FromBody] CreateRoundRequest request, CancellationToken cancellationToken = default)
        {
            return await mediator.Send(request, cancellationToken);
        }
    }
}
