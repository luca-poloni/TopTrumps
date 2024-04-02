namespace Domain.Core.Game
{
    public interface IGameRepository
    {
        void Add(GameEntity game);
        void Update(GameEntity game);
        void Delete(GameEntity game);
        Task<GameEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<GameEntity?> GetByIdAsNoTrackingAsync(Guid id, CancellationToken cancellationToken);
        Task<IEnumerable<GameEntity>> GetAllAsNoTrackingAsync(CancellationToken cancellationToken);
    }
}
