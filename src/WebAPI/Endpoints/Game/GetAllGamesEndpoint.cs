using Application.UseCases.Game.Queries.GetAllGames;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace WebAPI.Endpoints.Game
{
    public class GetAllGamesEndpoint(IMediator mediator) : EndpointBaseAsync.WithoutRequest.WithActionResult<IEnumerable<GetAllGamesResponse>>
    {
        [HttpGet("games/getAll")]
        [SwaggerOperation(OperationId = "Games.GetAll", Tags = ["Games"])]
        public override async Task<ActionResult<IEnumerable<GetAllGamesResponse>>> HandleAsync(CancellationToken cancellationToken = default)
        {
            return Ok(await mediator.Send(new GetAllGamesRequest(), cancellationToken));
        }
    }
}
