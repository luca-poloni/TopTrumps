using Application.UseCases.Power.Commands.UpdatePower;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace WebAPI.Endpoints.Power
{
    public class UpdatePowerEndpoint(IMediator mediator) : EndpointBaseAsync.WithRequest<UpdatePowerRequest>.WithActionResult<UpdatePowerResponse>
    {
        [Authorize(Roles = "Admin")]
        [HttpPut("powers/update")]
        [SwaggerOperation(OperationId = "Powers.Update", Tags = ["Powers"])]
        public override async Task<ActionResult<UpdatePowerResponse>> HandleAsync([FromBody] UpdatePowerRequest request, CancellationToken cancellationToken = default)
        {
            return await mediator.Send(request, cancellationToken);
        }
    }
}
