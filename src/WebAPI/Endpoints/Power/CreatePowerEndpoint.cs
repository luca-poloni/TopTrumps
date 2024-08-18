using Application.UseCases.Power.Commands.CreatePower;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace WebAPI.Endpoints.Power
{
    public class CreatePowerEndpoint(IMediator mediator) : EndpointBaseAsync.WithRequest<CreatePowerRequest>.WithActionResult<CreatePowerResponse>
    {
        [HttpPost("powers/create")]
        [SwaggerOperation(OperationId = "Powers.Create", Tags = ["Powers"])]
        public override async Task<ActionResult<CreatePowerResponse>> HandleAsync([FromBody] CreatePowerRequest request, CancellationToken cancellationToken = default)
        {
            return await mediator.Send(request, cancellationToken);
        }
    }
}
