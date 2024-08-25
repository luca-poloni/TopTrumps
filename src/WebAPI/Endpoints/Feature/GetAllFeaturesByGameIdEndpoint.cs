using Application.UseCases.Feature.Queries.GetAllFeaturesByGameId;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace WebAPI.Endpoints.Feature
{
    public class GetAllFeaturesByGameIdEndpoint(IMediator mediator) : EndpointBaseAsync.WithRequest<GetAllFeaturesByGameIdRequest>.WithActionResult<IEnumerable<GetAllFeaturesByGameIdResponse>>
    {
        [HttpGet("features/getAllByGameId")]
        [SwaggerOperation(OperationId = "Features.GetAllByGameId", Tags = ["Features"])]
        public override async Task<ActionResult<IEnumerable<GetAllFeaturesByGameIdResponse>>> HandleAsync([FromQuery] GetAllFeaturesByGameIdRequest request, CancellationToken cancellationToken = default)
        {
            return Ok(await mediator.Send(request, cancellationToken));
        }
    }
}
