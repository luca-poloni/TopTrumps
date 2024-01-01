using Domain.Entities;

namespace Domain.Repositores
{
    public interface IGameRepository
    {
        Task<GameEntity> GetById(uint id, CancellationToken cancellationToken);
    }
}
