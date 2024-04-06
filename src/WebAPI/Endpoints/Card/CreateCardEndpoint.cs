using Application.UseCases.Card.Commands.CreateCard;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace WebAPI.Endpoints.Card
{
    public class CreateCardEndpoint(IMediator mediator) : EndpointBaseAsync.WithRequest<CreateCardRequest>.WithActionResult<CreateCardResponse>
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost("cards/create")]
        [SwaggerOperation(OperationId = "Cards.Create", Tags = ["Cards"])]
        public override async Task<ActionResult<CreateCardResponse>> HandleAsync([FromBody] CreateCardRequest request, CancellationToken cancellationToken = default)
        {
            return await _mediator.Send(request, cancellationToken);
        }
    }
}
