namespace Domain.Core.Card
{
    public interface ICardRepository
    {
        void Add(CardEntity card);
        void Update(CardEntity card);
        void Delete(CardEntity card);
        Task<CardEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<CardEntity?> GetByIdAsNoTrackingAsync(Guid id, CancellationToken cancellationToken);
        Task<IEnumerable<CardEntity>> GetAllAsNoTrackingAsync(CancellationToken cancellationToken);
    }
}
