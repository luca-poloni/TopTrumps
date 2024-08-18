using Application.UseCases.Power.Queries.GetPowerByCardId;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace WebAPI.Endpoints.Power
{
    public class GetPowerByIdEndpoint(IMediator mediator) : EndpointBaseAsync.WithRequest<GetPowerByIdRequest>.WithActionResult<GetPowerByIdResponse>
    {
        [HttpGet("powers/getById")]
        [SwaggerOperation(OperationId = "Powers.GetById", Tags = ["Powers"])]
        public override async Task<ActionResult<GetPowerByIdResponse>> HandleAsync([FromQuery] GetPowerByIdRequest request, CancellationToken cancellationToken = default)
        {
            return await mediator.Send(request, cancellationToken);
        }
    }
}
