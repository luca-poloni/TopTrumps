using Ardalis.Specification;

namespace Domain.Game.Specifications.AsNoTracking
{
    public class GameWithAllRoundsByMatchIdAsNoTrackingSpecification : SingleResultSpecification<GameAggregate>
    {
        public GameWithAllRoundsByMatchIdAsNoTrackingSpecification(Guid matchId)
        {
            Query
                .Include(game => game.Matches.Where(match => match.Id == matchId))
                .ThenInclude(match => match.Rounds)
                .Where(game => game.Matches.Any(match => match.Id == matchId))
                .AsNoTracking();
        }
    }
}
