namespace Domain.Round
{
    public interface IRoundRepository
    {
        Task<RoundEntity> GetById(uint id, CancellationToken cancellationToken);
        Task<RoundEntity> GetAll(CancellationToken cancellationToken);
    }
}
