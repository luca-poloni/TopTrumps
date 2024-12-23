using Application.UseCases.Card.Commands.UpdateCard;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace WebAPI.Endpoints.Card
{
    public class UpdateCardEndpoint(IMediator mediator) : EndpointBaseAsync.WithRequest<UpdateCardRequest>.WithActionResult<UpdateCardResponse>
    {
        [Authorize(Roles = "Admin")]
        [HttpPut("cards/update")]
        [SwaggerOperation(OperationId = "Cards.Update", Tags = ["Cards"])]
        public override async Task<ActionResult<UpdateCardResponse>> HandleAsync([FromBody] UpdateCardRequest request, CancellationToken cancellationToken = default)
        {
            return await mediator.Send(request, cancellationToken);
        }
    }
}
