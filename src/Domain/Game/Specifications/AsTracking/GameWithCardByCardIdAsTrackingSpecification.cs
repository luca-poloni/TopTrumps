using Ardalis.Specification;

namespace Domain.Game.Specifications.AsTracking
{
    public class GameWithCardByCardIdAsTrackingSpecification : SingleResultSpecification<GameAggregate>
    {
        public GameWithCardByCardIdAsTrackingSpecification(Guid cardId)
        {
            Query
                .Include(game => game.Cards.Where(card => card.Id == cardId))
                .Where(game => game.Cards.Any(card => card.Id == cardId));
        }
    }
}
