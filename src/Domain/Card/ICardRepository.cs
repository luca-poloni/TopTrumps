namespace Domain.Card
{
    public interface IGameRepository
    {
        Task<CardEntity> GetById(uint id, CancellationToken cancellationToken);
        Task<CardEntity> GetAll(CancellationToken cancellationToken);
    }
}
