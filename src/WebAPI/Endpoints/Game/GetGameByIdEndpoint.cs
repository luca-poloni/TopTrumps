using Application.UseCases.Game.Queries.GetGameById;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Endpoints.Game
{
    public class GetGameByIdEndpoint(IMediator mediator) : EndpointBaseAsync.WithRequest<GetGameByIdRequest>.WithActionResult<GetGameByIdResponse>
    {
        private readonly IMediator _mediator = mediator;

        [HttpGet("/game")]
        public override async Task<ActionResult<GetGameByIdResponse>> HandleAsync([FromQuery] GetGameByIdRequest request, CancellationToken cancellationToken = default)
        {
            return await _mediator.Send(request, cancellationToken);
        }
    }
}
