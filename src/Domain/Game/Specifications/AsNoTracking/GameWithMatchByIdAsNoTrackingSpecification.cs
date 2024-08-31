using Ardalis.Specification;

namespace Domain.Game.Specifications.AsNoTracking
{
    public class GameWithMatchByIdAsNoTrackingSpecification : SingleResultSpecification<GameAggregate>
    {
        public GameWithMatchByIdAsNoTrackingSpecification(Guid matchId)
        {
            Query
                .Include(game => game.Matches.Where(match => match.Id == matchId))
                .Where(game => game.Matches.Any(match => match.Id == matchId))
                .AsNoTracking();
        }
    }
}
