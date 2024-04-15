using Application.UseCases.Feature.Commands.UpdateFeature;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace WebAPI.Endpoints.Feature
{
    public class UpdateFeatureEndpoint(IMediator mediator) : EndpointBaseAsync.WithRequest<UpdateFeatureRequest>.WithActionResult<UpdateFeatureResponse>
    {
        private readonly IMediator _mediator = mediator;

        [HttpPut("features/update")]
        [SwaggerOperation(OperationId = "Features.Update", Tags = ["Features"])]
        public override async Task<ActionResult<UpdateFeatureResponse>> HandleAsync([FromBody] UpdateFeatureRequest request, CancellationToken cancellationToken = default)
        {
            return await _mediator.Send(request, cancellationToken);
        }
    }
}
