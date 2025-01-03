﻿using Application.UseCases.Card.Commands.CreateCard;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace WebAPI.Endpoints.Card
{
    public class CreateCardEndpoint(IMediator mediator) : EndpointBaseAsync.WithRequest<CreateCardRequest>.WithActionResult<CreateCardResponse>
    {
        [Authorize(Roles = "Admin")]
        [HttpPost("cards/create")]
        [SwaggerOperation(OperationId = "Cards.Create", Tags = ["Cards"])]
        public override async Task<ActionResult<CreateCardResponse>> HandleAsync([FromBody] CreateCardRequest request, CancellationToken cancellationToken = default)
        {
            return await mediator.Send(request, cancellationToken);
        }
    }
}
