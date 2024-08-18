using Ardalis.Specification;

namespace Domain.Game.Specifications
{
    public class GameToGetCardsSpecification : SingleResultSpecification<GameAggregate>
    {
        public GameToGetCardsSpecification(Guid id)
        {
            Query
                .Include(game => game.Cards)
                .Where(game => game.Id == id);
        }
    }
}
