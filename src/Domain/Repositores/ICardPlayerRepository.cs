using Domain.Entities;

namespace Domain.Repositores
{
    public interface ICardPlayerRepository
    {
        Task<CardPlayerEntity> GetById(uint id, CancellationToken cancellationToken);
    }
}
