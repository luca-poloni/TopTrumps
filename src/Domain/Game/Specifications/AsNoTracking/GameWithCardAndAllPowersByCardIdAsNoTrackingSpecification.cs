using Ardalis.Specification;

namespace Domain.Game.Specifications.AsNoTracking
{
    public class GameWithCardAndAllPowersByCardIdAsNoTrackingSpecification : SingleResultSpecification<GameAggregate>
    {
        public GameWithCardAndAllPowersByCardIdAsNoTrackingSpecification(Guid cardId)
        {
            Query
                .Include(game => game.Cards.Where(card => card.Id == cardId))
                .ThenInclude(card => card.Powers)
                .Where(game => game.Cards.Any(card => card.Id == cardId))
                .AsNoTracking();
        }
    }
}
