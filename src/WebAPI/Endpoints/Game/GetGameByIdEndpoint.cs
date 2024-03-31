using Application.UseCases.Game.Queries.GetGameById;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace WebAPI.Endpoints.Game
{
    public class GetGameByIdEndpoint(IMediator mediator) : EndpointBaseAsync.WithRequest<GetGameByIdRequest>.WithActionResult<GetGameByIdResponse>
    {
        private readonly IMediator _mediator = mediator;

        [HttpGet("games/getById")]
        [SwaggerOperation(OperationId = "Games.GetById", Tags = ["Games"])]
        public override async Task<ActionResult<GetGameByIdResponse>> HandleAsync([FromQuery] GetGameByIdRequest request, CancellationToken cancellationToken = default)
        {
            return await _mediator.Send(request, cancellationToken);
        }
    }
}
