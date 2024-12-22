using Ardalis.Specification;

namespace Domain.Game.Specifications.AsNoTracking
{
    public class GameWithMatchAndRoundByRoundIdAsNoTrackingSpecification : SingleResultSpecification<GameAggregate>
    {
        public GameWithMatchAndRoundByRoundIdAsNoTrackingSpecification(Guid roundId)
        {
            Query
                .Include(game => game.Matches.Where(match => match.Rounds.Any(round => round.Id == roundId)))
                .ThenInclude(match => match.Rounds.Where(round => round.Id == roundId))
                .Where(game => game.Matches.Any(match => match.Rounds.Any(round => round.Id == roundId)))
                .AsNoTracking();
        }
    }
}
