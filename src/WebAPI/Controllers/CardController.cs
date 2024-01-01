using Application.UseCases.Card.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("Card")]
    [ApiController]
    public class CardController(IMediator mediator)
    {
        private readonly IMediator _mediator = mediator;

        [Route("Create")]
        [HttpPost]
        public async Task<ActionResult<CreateCardResponse>> Create([FromBody] CreateCardRequest request)
        {
            return await _mediator.Send(request);
        }
    }
}
