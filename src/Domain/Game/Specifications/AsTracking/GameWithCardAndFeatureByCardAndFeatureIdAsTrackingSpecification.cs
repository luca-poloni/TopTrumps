using Ardalis.Specification;

namespace Domain.Game.Specifications.AsTracking
{
    public class GameWithCardAndFeatureByCardAndFeatureIdAsTrackingSpecification : SingleResultSpecification<GameAggregate>
    {
        public GameWithCardAndFeatureByCardAndFeatureIdAsTrackingSpecification(Guid cardId, Guid featureId)
        {
            Query
                .Include(game => game.Cards.Where(card => card.Id == cardId))
                .Include(game => game.Features.Where(feature => feature.Id == featureId))
                .Where(game => game.Cards.Any(card => card.Id == cardId)
                    && game.Features.Any(feature => feature.Id == featureId));
        }
    }
}
