using Application.UseCases.Feature.Commands.CreateFeature;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace WebAPI.Endpoints.Feature
{
    public class CreateFeatureEndpoint(IMediator mediator) : EndpointBaseAsync.WithRequest<CreateFeatureRequest>.WithActionResult<CreateFeatureResponse>
    {
        [HttpPost("features/create")]
        [SwaggerOperation(OperationId = "Features.Create", Tags = ["Features"])]
        public override async Task<ActionResult<CreateFeatureResponse>> HandleAsync([FromBody] CreateFeatureRequest request, CancellationToken cancellationToken = default)
        {
            return await mediator.Send(request, cancellationToken);
        }
    }
}
