namespace Domain.CardRound
{
    public interface ICardRoundRepository
    {
        Task<CardRoundEntity> GetById(uint id, CancellationToken cancellationToken);
        Task<CardRoundEntity> GetAll(CancellationToken cancellationToken);
    }
}
