using Ardalis.Specification;

namespace Domain.Game.Specifications.AsNoTracking
{
    public class GameWithAllFeaturesByIdAsNoTrackingSpecification : SingleResultSpecification<GameAggregate>
    {
        public GameWithAllFeaturesByIdAsNoTrackingSpecification(Guid id)
        {
            Query
                .Include(game => game.Features)
                .Where(game => game.Id == id)
                .AsNoTracking();
        }
    }
}
