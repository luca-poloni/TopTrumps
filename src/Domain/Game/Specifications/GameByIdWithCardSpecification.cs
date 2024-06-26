using Ardalis.Specification;

namespace Domain.Game.Specifications
{
    public class GameByIdWithCardSpecification : SingleResultSpecification<GameAggregate>
    {
        public GameByIdWithCardSpecification(Guid id)
        {
            Query
                .Include(game => game.Cards)
                .Where(game => game.Id == id);
        }
    }
}
