using Ardalis.Specification;

namespace Domain.Game.Specifications.AsTracking
{
    public class GameWithMatchByIdAsTrackingSpecification : SingleResultSpecification<GameAggregate>
    {
        public GameWithMatchByIdAsTrackingSpecification(Guid matchId)
        {
            Query
                .Include(game => game.Matches.Where(match => match.Id == matchId))
                .Where(game => game.Matches.Any(match => match.Id == matchId));
        }
    }
}
