using Application.UseCases.Power.Commands.DeletePower;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace WebAPI.Endpoints.Power;

public class DeletePowerEndpoint(IMediator mediator) : EndpointBaseAsync.WithRequest<DeletePowerRequest>.WithoutResult
{
    [HttpDelete("powers/delete")]
    [SwaggerOperation(OperationId = "Power.Delete", Tags = ["Powers"])]
    public override async Task HandleAsync([FromQuery] DeletePowerRequest request, CancellationToken cancellationToken = default)
    {
        await mediator.Send(request, cancellationToken);
    }
}
