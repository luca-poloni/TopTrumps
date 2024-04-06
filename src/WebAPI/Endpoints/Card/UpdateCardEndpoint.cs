using Application.UseCases.Card.Commands.UpdateCard;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace WebAPI.Endpoints.Card
{
    public class UpdateCardEndpoint(IMediator mediator) : EndpointBaseAsync.WithRequest<UpdateCardRequest>.WithActionResult<UpdateCardResponse>
    {
        private readonly IMediator _mediator = mediator;

        [HttpPut("cards/update")]
        [SwaggerOperation(OperationId = "Cards.Update", Tags = ["Cards"])]
        public override async Task<ActionResult<UpdateCardResponse>> HandleAsync([FromBody] UpdateCardRequest request, CancellationToken cancellationToken = default)
        {
            return await _mediator.Send(request, cancellationToken);
        }
    }
}
