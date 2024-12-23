using Application.UseCases.Feature.Commands.UpdateFeature;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace WebAPI.Endpoints.Feature
{
    public class UpdateFeatureEndpoint(IMediator mediator) : EndpointBaseAsync.WithRequest<UpdateFeatureRequest>.WithActionResult<UpdateFeatureResponse>
    {
        [Authorize(Roles = "Admin")]
        [HttpPut("features/update")]
        [SwaggerOperation(OperationId = "Features.Update", Tags = ["Features"])]
        public override async Task<ActionResult<UpdateFeatureResponse>> HandleAsync([FromBody] UpdateFeatureRequest request, CancellationToken cancellationToken = default)
        {
            return await mediator.Send(request, cancellationToken);
        }
    }
}
