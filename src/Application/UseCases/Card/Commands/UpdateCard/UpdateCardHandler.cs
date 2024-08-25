using Ardalis.SharedKernel;
using Domain.Game;
using Domain.Game.Specifications.AsTracking;
using MediatR;

namespace Application.UseCases.Card.Commands.UpdateCard
{
    internal class UpdateCardHandler(IRepository<GameAggregate> repository) : IRequestHandler<UpdateCardRequest, UpdateCardResponse>
    {
        public async Task<UpdateCardResponse> Handle(UpdateCardRequest request, CancellationToken cancellationToken)
        {
            var game = await repository
                .SingleOrDefaultAsync(new GameWithCardByCardIdAsTrackingSpecification(request.Id), cancellationToken) 
                    ?? throw new ArgumentException($"Game not found to update card with {request.Id} card id.");

            var card = game.SingleCard();

            card.Update(request.Name, request.IsTopTrumps);

            await repository
                .SaveChangesAsync(cancellationToken);

            var response = new UpdateCardResponse
            {
                Id = card.Id,
                GameId = card.GameId,
                Name = card.Name,
                IsTopTrumps = card.IsTopTrumps
            };

            return response;
        }
    }
}
