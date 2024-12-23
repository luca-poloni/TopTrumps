using Application.UseCases.Card.Queries.GetCardById;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace WebAPI.Endpoints.Card
{
    public class GetCardByIdEndpoint(IMediator mediator) : EndpointBaseAsync.WithRequest<GetCardByIdRequest>.WithActionResult<GetCardByIdResponse>
    {
        [Authorize(Roles = "Admin")]
        [HttpGet("cards/getById")]
        [SwaggerOperation(OperationId = "Cards.GetById", Tags = ["Cards"])]
        public override async Task<ActionResult<GetCardByIdResponse>> HandleAsync([FromQuery] GetCardByIdRequest request, CancellationToken cancellationToken = default)
        {
            return await mediator.Send(request, cancellationToken);
        }
    }
}
