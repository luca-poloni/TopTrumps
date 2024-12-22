using Ardalis.Specification;

namespace Domain.Game.Specifications.AsTracking
{
    public class GameWithMatchAndRoundByRoundIdAsTrackingSpecification : SingleResultSpecification<GameAggregate>
    {
        public GameWithMatchAndRoundByRoundIdAsTrackingSpecification(Guid roundId)
        {
            Query
                .Include(game => game.Matches.Where(match => match.Rounds.Any(round => round.Id == roundId)))
                .ThenInclude(match => match.Rounds.Where(round => round.Id == roundId))
                .Where(game => game.Matches.Any(match => match.Rounds.Any(round => round.Id == roundId)));
        }
    }
}
