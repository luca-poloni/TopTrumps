using Application.UseCases.Feature.Queries.GetAllFeatures;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace WebAPI.Endpoints.Feature
{
    public class GetAllFeaturesEndpoint(IMediator mediator) : EndpointBaseAsync.WithRequest<GetAllFeaturesRequest>.WithActionResult<IEnumerable<GetAllFeaturesResponse>>
    {
        [HttpGet("features/getAll")]
        [SwaggerOperation(OperationId = "Features.GetAll", Tags = ["Features"])]
        public override async Task<ActionResult<IEnumerable<GetAllFeaturesResponse>>> HandleAsync([FromQuery] GetAllFeaturesRequest request, CancellationToken cancellationToken = default)
        {
            return Ok(await mediator.Send(request, cancellationToken));
        }
    }
}
