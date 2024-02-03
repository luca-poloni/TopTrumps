namespace Domain.Player
{
    public interface IPlayerRepository
    {
        Task<PlayerEntity> GetById(uint id, CancellationToken cancellationToken);
        Task<PlayerEntity> GetAll(CancellationToken cancellationToken);
    }
}
