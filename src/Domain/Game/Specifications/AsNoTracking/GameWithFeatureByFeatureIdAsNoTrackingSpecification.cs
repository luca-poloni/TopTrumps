using Ardalis.Specification;

namespace Domain.Game.Specifications.AsNoTracking
{
    public class GameWithFeatureByFeatureIdAsNoTrackingSpecification : SingleResultSpecification<GameAggregate>
    {
        public GameWithFeatureByFeatureIdAsNoTrackingSpecification(Guid featureId)
        {
            Query
                .Include(game => game.Features.Where(feature => feature.Id == featureId))
                .Where(game => game.Features.Any(feature => feature.Id == featureId))
                .AsNoTracking();
        }
    }
}
