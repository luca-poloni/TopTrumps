using Ardalis.Specification;

namespace Domain.Game.Specifications
{
    public class GameByIdWithFeatureSpecification : SingleResultSpecification<GameAggregate>
    {
        public GameByIdWithFeatureSpecification(Guid id)
        {
            Query
                .Include(game => game.Features)
                .Where(game => game.Id == id);
        }
    }
}
