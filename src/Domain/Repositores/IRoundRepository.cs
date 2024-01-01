using Domain.Entities;

namespace Domain.Repositores
{
    public interface IRoundRepository
    {
        Task<RoundEntity> GetById(uint id, CancellationToken cancellationToken);
    }
}
