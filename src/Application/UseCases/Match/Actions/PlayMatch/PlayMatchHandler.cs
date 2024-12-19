using Ardalis.SharedKernel;
using Domain.Game;
using Domain.Game.Specifications.AsTracking;
using MediatR;

namespace Application.UseCases.Match.Actions.PlayGame
{
    internal sealed class PlayMatchHandler(IRepository<GameAggregate> repository) : IRequestHandler<PlayMatchRequest>
    {
        public async Task Handle(PlayMatchRequest request, CancellationToken cancellationToken)
        {
            var game = await repository
                .SingleOrDefaultAsync(new GameWithCardsAndMatchAndPlayersByMatchIdAsTrackingSpecification(request.Id), cancellationToken)
                    ?? throw new ArgumentException($"Game not found with '{request.Id}' match id to play match.");

            game.ShuffledCards();

            var match = game.SingleMatch();

            match.AddMatchCards();

            var matchCardsPerPlayer =  match.MatchCardsPerPlayer();

            match.GiveMatchCardsToPlayers(matchCardsPerPlayer);

            await repository
                .SaveChangesAsync(cancellationToken);
        }
    }
}
