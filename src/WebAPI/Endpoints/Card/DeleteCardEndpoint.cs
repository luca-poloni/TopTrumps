using Application.UseCases.Card.Commands.DeleteCard;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace WebAPI.Endpoints.Card
{
    public class DeleteCardEndpoint(IMediator mediator) : EndpointBaseAsync.WithRequest<DeleteCardRequest>.WithoutResult
    {
        [HttpDelete("cars/delete")]
        [SwaggerOperation(OperationId = "Cards.Delete", Tags = ["Cards"])]
        public override async Task HandleAsync([FromQuery] DeleteCardRequest request, CancellationToken cancellationToken = default)
        {
            await mediator.Send(request, cancellationToken);
        }
    }
}
