using Application.UseCases.Game.Commands.UpdateGame;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace WebAPI.Endpoints.Game
{
    public class UpdateGameEndpoint(IMediator mediator) : EndpointBaseAsync.WithRequest<UpdateGameRequest>.WithActionResult<UpdateGameResponse>
    {
        [HttpPut("games/update")]
        [SwaggerOperation(OperationId = "Games.Update", Tags = ["Games"])]
        public override async Task<ActionResult<UpdateGameResponse>> HandleAsync([FromBody] UpdateGameRequest request, CancellationToken cancellationToken = default)
        {
            return await mediator.Send(request, cancellationToken);
        }
    }
}
