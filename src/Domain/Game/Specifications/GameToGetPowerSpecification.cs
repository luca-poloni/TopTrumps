using Ardalis.Specification;

namespace Domain.Game.Specifications
{
    public class GameToGetPowerSpecification : SingleResultSpecification<GameAggregate>
    {
        public GameToGetPowerSpecification(Guid powerId)
        {
            Query
                .Include(game => game.Cards.Where(card => card.Powers.Any(power => power.Id == powerId)))
                .ThenInclude(card => card.Powers)
                .Where(game => game.Cards.Any(card => card.Powers.Any(power => power.Id == powerId)));
        }
    }
}
