using Ardalis.Specification;

namespace Domain.Game.Specifications.AsTracking
{
    public class GameWithAllFeaturesByIdAsTrackingSpecification : SingleResultSpecification<GameAggregate>
    {
        public GameWithAllFeaturesByIdAsTrackingSpecification(Guid id)
        {
            Query
                .Include(game => game.Features)
                .Where(game => game.Id == id);
        }
    }
}
