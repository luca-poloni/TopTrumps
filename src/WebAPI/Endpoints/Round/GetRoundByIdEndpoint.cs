using Application.UseCases.Round.Queries.GetRoundById;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace WebAPI.Endpoints.Round
{
    public class GetRoundByIdEndpoint(IMediator mediator) : EndpointBaseAsync.WithRequest<GetRoundByIdRequest>.WithActionResult<GetRoundByIdResponse>
    {
        [HttpGet("rounds/getById")]
        [SwaggerOperation(OperationId = "Rounds.GetById", Tags = ["Rounds"])]
        public override async Task<ActionResult<GetRoundByIdResponse>> HandleAsync([FromQuery] GetRoundByIdRequest request, CancellationToken cancellationToken = default)
        {
            return await mediator.Send(request, cancellationToken);
        }
    }
}
