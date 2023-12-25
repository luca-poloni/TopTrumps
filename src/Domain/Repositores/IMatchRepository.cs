using Domain.Entities;

namespace Domain.Repositores
{
    public interface IMatchRepository
    {
        Task<MatchEntity> GetById(uint id, CancellationToken cancellationToken);
    }
}
