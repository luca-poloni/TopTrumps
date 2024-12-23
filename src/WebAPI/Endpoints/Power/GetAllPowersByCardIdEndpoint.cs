using Application.UseCases.Power.Queries.GetAllPowersByCardId;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace WebAPI.Endpoints.Power
{
    public class GetAllPowersByCardIdEndpoint(IMediator mediator) : EndpointBaseAsync.WithRequest<GetAllPowersByCardIdRequest>.WithActionResult<IEnumerable<GetAllPowersByCardIdResponse>>
    {
        [Authorize(Roles = "Admin")]
        [HttpGet("powers/getAllByCardId")]
        [SwaggerOperation(OperationId = "Powers.GetAllByCardId", Tags = ["Powers"])]
        public override async Task<ActionResult<IEnumerable<GetAllPowersByCardIdResponse>>> HandleAsync([FromQuery] GetAllPowersByCardIdRequest request, CancellationToken cancellationToken = default)
        {
            return Ok(await mediator.Send(request, cancellationToken));
        }
    }
}
