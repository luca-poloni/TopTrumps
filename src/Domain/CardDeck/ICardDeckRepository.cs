namespace Domain.CardDeck
{
    public interface ICardDeckRepository
    {
        Task<CardDeckEntity> GetById(uint id, CancellationToken cancellationToken);
        Task<CardDeckEntity> GetAll(CancellationToken cancellationToken);
    }
}
