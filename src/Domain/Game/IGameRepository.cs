namespace Domain.Game
{
    public interface IGameRepository
    {
        Task<GameEntity> GetById(uint id, CancellationToken cancellationToken);
        Task<GameEntity> GetAll(CancellationToken cancellationToken);
    }
}
