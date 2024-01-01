using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Card.Commands
{
    internal class CreateCardHandler(IApplicationDbContext context) : IRequestHandler<CreateCardRequest, CreateCardResponse>
    {
        private readonly IApplicationDbContext _context = context;

        public async Task<CreateCardResponse> Handle(CreateCardRequest request, CancellationToken cancellationToken)
        {
            var card = new CardEntity(request.GameId, request.Name, request.Image, request.IsTopTrumps);

            await _context.Cards.AddAsync(card, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            var response = new CreateCardResponse
            {
                Id = card.Id,
                Name = card.Name,
                GameId = card.GameId,
                Image = card.Image,
                IsTopTrumps = card.IsTopTrumps
            };

            return response;
        }
    }
}
