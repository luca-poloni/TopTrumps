using Application.UseCases.Card.Queries.GetAllCardsByGameId;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace WebAPI.Endpoints.Card
{
    public class GetAllCardsByGameIdEndpoint(IMediator mediator) : EndpointBaseAsync.WithRequest<GetAllCardsByGameIdRequest>.WithActionResult<IEnumerable<GetAllCardsByGameIdResponse>>
    {
        [HttpGet("cards/getAllByGameId")]
        [SwaggerOperation(OperationId = "Cards.GetAllByGameId", Tags = ["Cards"])]
        public override async Task<ActionResult<IEnumerable<GetAllCardsByGameIdResponse>>> HandleAsync([FromQuery] GetAllCardsByGameIdRequest request, CancellationToken cancellationToken = default)
        {
            return Ok(await mediator.Send(request, cancellationToken));
        }
    }
}
