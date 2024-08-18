using Ardalis.Specification;

namespace Domain.Game.Specifications
{
    public class GameToGetAllPowersReadOnlySpecification : SingleResultSpecification<GameAggregate>
    {
        public GameToGetAllPowersReadOnlySpecification(Guid cardId)
        {
            Query
                .Include(game => game.Cards.Where(card => card.Id == cardId))
                .ThenInclude(card => card.Powers)
                .Where(game => game.Cards.Any(card => card.Id == cardId))
                .AsNoTracking();
        }
    }
}
