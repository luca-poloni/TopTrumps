using Application.UseCases.Feature.Queries.GetFeatureById;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace WebAPI.Endpoints.Feature
{
    public class GetFeatureByIdEndpoint(IMediator mediator) : EndpointBaseAsync.WithRequest<GetFeatureByIdRequest>.WithActionResult<GetFeatureByIdResponse>
    {
        private readonly IMediator _mediator = mediator;

        [HttpGet("features/getById")]
        [SwaggerOperation(OperationId = "Features.GetById", Tags = ["Features"])]
        public override async Task<ActionResult<GetFeatureByIdResponse>> HandleAsync([FromQuery] GetFeatureByIdRequest request, CancellationToken cancellationToken = default)
        {
            return await _mediator.Send(request, cancellationToken);
        }
    }
}
