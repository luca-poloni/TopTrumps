using Ardalis.Specification;

namespace Domain.Game.Specifications.AsTracking
{
    public class GameWithCardsAndMatchAndPlayersByMatchIdAsTrackingSpecification : SingleResultSpecification<GameAggregate>
    {
        public GameWithCardsAndMatchAndPlayersByMatchIdAsTrackingSpecification(Guid matchId)
        {
            Query
                .Include(game => game.Cards)
                .Include(game => game.Matches.Where(match => match.Id == matchId))
                .ThenInclude(match => match.Players)
                .Where(game => game.Matches.Any(match => match.Id == matchId));
        }
    }
}
