using Ardalis.Specification;

namespace Domain.Game.Specifications.AsTracking
{
    public class GameWithCardByPowerIdAsTrackingSpecification : SingleResultSpecification<GameAggregate>
    {
        public GameWithCardByPowerIdAsTrackingSpecification(Guid powerId)
        {
            Query
                .Include(game => game.Cards.Where(card => card.Powers.Any(power => power.Id == powerId)))
                .ThenInclude(card => card.Powers.Where(power => power.Id == powerId))
                .Where(game => game.Cards.Any(card => card.Powers.Any(power => power.Id == powerId)));
        }
    }
}
