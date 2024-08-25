using Ardalis.Specification;

namespace Domain.Game.Specifications.AsNoTracking
{
    public class GameWithCardByCardIdAsNoTrackingSpecification : SingleResultSpecification<GameAggregate>
    {
        public GameWithCardByCardIdAsNoTrackingSpecification(Guid cardId)
        {
            Query
                .Include(game => game.Cards.Where(card => card.Id == cardId))
                .Where(game => game.Cards.Any(card => card.Id == cardId))
                .AsNoTracking();
        }
    }
}