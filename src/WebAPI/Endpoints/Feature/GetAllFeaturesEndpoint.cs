using Application.UseCases.Feature.Queries.GetAllFeatures;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace WebAPI.Endpoints.Feature
{
    public class GetAllFeaturesEndpoint(IMediator mediator) : EndpointBaseAsync.WithoutRequest.WithActionResult<IEnumerable<GetAllFeaturesResponse>>
    {
        private readonly IMediator _mediator = mediator;

        [HttpGet("features/getAll")]
        [SwaggerOperation(OperationId = "Features.GetAll", Tags = ["Features"])]
        public override async Task<ActionResult<IEnumerable<GetAllFeaturesResponse>>> HandleAsync(CancellationToken cancellationToken = default)
        {
            return Ok(await _mediator.Send(new GetAllFeaturesRequest(), cancellationToken));
        }
    }
}
