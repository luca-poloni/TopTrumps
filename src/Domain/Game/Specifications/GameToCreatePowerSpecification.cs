using Ardalis.Specification;

namespace Domain.Game.Specifications
{
    public class GameToCreatePowerSpecification : SingleResultSpecification<GameAggregate>
    {
        public GameToCreatePowerSpecification(Guid cardId)
        {
            Query
                .Include(game => game.Cards.Where(card => card.Id == cardId))
                .Include(game => game.Features)
                .Where(game => game.Cards.Any(card => card.Id == cardId));
        }
    }
}
