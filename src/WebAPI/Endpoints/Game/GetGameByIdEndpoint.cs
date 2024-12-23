using Application.UseCases.Game.Queries.GetGameById;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace WebAPI.Endpoints.Game
{
    public class GetGameByIdEndpoint(IMediator mediator) : EndpointBaseAsync.WithRequest<GetGameByIdRequest>.WithActionResult<GetGameByIdResponse>
    {
        [Authorize(Roles = "User")]
        [HttpGet("games/getById")]
        [SwaggerOperation(OperationId = "Games.GetById", Tags = ["Games"])]
        public override async Task<ActionResult<GetGameByIdResponse>> HandleAsync([FromQuery] GetGameByIdRequest request, CancellationToken cancellationToken = default)
        {
            return await mediator.Send(request, cancellationToken);
        }
    }
}
