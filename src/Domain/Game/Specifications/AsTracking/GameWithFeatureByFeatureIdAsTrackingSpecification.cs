using Ardalis.Specification;

namespace Domain.Game.Specifications.AsTracking
{
    public class GameWithFeatureByFeatureIdAsTrackingSpecification : SingleResultSpecification<GameAggregate>
    {
        public GameWithFeatureByFeatureIdAsTrackingSpecification(Guid featureId)
        {
            Query
                .Include(game => game.Features.Where(feature => feature.Id == featureId))
                .Where(game => game.Features.Any(feature => feature.Id == featureId));
        }
    }
}
