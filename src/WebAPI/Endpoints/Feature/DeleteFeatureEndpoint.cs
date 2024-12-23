using Application.UseCases.Feature.Commands.DeleteFeature;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace WebAPI.Endpoints.Feature
{
    public class DeleteFeatureEndpoint(IMediator mediator) : EndpointBaseAsync.WithRequest<DeleteFeatureRequest>.WithoutResult
    {
        [Authorize(Roles = "Admin")]
        [HttpDelete("features/delete")]
        [SwaggerOperation(OperationId = "Features.Delete", Tags = ["Features"])]
        public override async Task HandleAsync([FromQuery] DeleteFeatureRequest request, CancellationToken cancellationToken = default)
        {
            await mediator.Send(request, cancellationToken);
        }
    }
}
