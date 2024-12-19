using Application.UseCases.Player.Queries.GetPlayerById;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace WebAPI.Endpoints.Player
{
    public class GetPlayerByIdEndpoint(IMediator mediator) : EndpointBaseAsync.WithRequest<GetPlayerByIdRequest>.WithActionResult<GetPlayerByIdResponse>
    {
        [HttpGet("players/getById")]
        [SwaggerOperation(OperationId = "Players.GetById", Tags = ["Players"])]
        public override async Task<ActionResult<GetPlayerByIdResponse>> HandleAsync([FromQuery] GetPlayerByIdRequest request, CancellationToken cancellationToken = default)
        {
            return await mediator.Send(request, cancellationToken);
        }
    }
}
