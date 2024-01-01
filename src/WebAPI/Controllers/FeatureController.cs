using Application.UseCases.Feature.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("Feature")]
    [ApiController]
    public class FeatureController(IMediator mediator)
    {
        private readonly IMediator _mediator = mediator;

        [Route("Create")]
        [HttpPost]
        public async Task<ActionResult<CreateFeatureResponse>> Create([FromBody] CreateFeatureRequest request)
        {
            return await _mediator.Send(request);
        }
    }
}
