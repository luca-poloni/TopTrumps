using Ardalis.Specification;

namespace Domain.Game.Specifications.AsNoTracking
{
    public class GameWithAllMatchesByIdAsNoTrackingSpecification : SingleResultSpecification<GameAggregate>
    {
        public GameWithAllMatchesByIdAsNoTrackingSpecification(Guid id)
        {
            Query
                .Include(game => game.Matches)
                .Where(game => game.Id == id)
                .AsNoTracking();
        }
    }
}
