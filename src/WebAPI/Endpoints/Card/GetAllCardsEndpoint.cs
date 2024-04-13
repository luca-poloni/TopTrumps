using Application.UseCases.Card.Queries.GetAllCards;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace WebAPI.Endpoints.Card
{
    public class GetAllCardsEndpoint(IMediator mediator) : EndpointBaseAsync.WithoutRequest.WithActionResult<IEnumerable<GetAllCardsResponse>>
    {
        private readonly IMediator _mediator = mediator;

        [HttpGet("cards/getAll")]
        [SwaggerOperation(OperationId = "Cards.GetAll", Tags = ["Cards"])]
        public override async Task<ActionResult<IEnumerable<GetAllCardsResponse>>> HandleAsync(CancellationToken cancellationToken = default)
        {
            return Ok(await _mediator.Send(new GetAllCardsRequest(), cancellationToken));
        }
    }
}
