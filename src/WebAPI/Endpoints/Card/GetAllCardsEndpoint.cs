using Application.UseCases.Card.Queries.GetAllCards;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace WebAPI.Endpoints.Card
{
    public class GetAllCardsEndpoint(IMediator mediator) : EndpointBaseAsync.WithRequest<GetAllCardsRequest>.WithActionResult<IEnumerable<GetAllCardsResponse>>
    {
        [HttpGet("cards/getAll")]
        [SwaggerOperation(OperationId = "Cards.GetAll", Tags = ["Cards"])]
        public override async Task<ActionResult<IEnumerable<GetAllCardsResponse>>> HandleAsync([FromQuery] GetAllCardsRequest request, CancellationToken cancellationToken = default)
        {
            return Ok(await mediator.Send(request, cancellationToken));
        }
    }
}
