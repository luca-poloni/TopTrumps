using Ardalis.Specification;

namespace Domain.Game.Specifications
{
    public class GameToGetFeaturesSpecification : SingleResultSpecification<GameAggregate>
    {
        public GameToGetFeaturesSpecification(Guid id)
        {
            Query
                .Include(game => game.Features)
                .Where(game => game.Id == id);
        }
    }
}
