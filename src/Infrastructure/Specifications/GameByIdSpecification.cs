using Ardalis.Specification;
using Domain.Core.Game;

namespace Infrastructure.Specifications
{
    internal class GameByIdSpecification : SingleResultSpecification<GameEntity>
    {
        public GameByIdSpecification(Guid id)
        {
            Query.Where(game => game.Id == id);
        }
    }
}
