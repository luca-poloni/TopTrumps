namespace Domain.Match
{
    public interface IMatchRepository
    {
        Task<MatchEntity> GetById(uint id, CancellationToken cancellationToken);
        Task<MatchEntity> GetAll(CancellationToken cancellationToken);
    }
}
