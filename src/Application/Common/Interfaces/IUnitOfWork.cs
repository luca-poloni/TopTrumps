using Domain.Game;

namespace Application.Common.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGameRepository GameRepository { get; }
        Task<int> CommitAsync(CancellationToken cancellationToken);
    }
}
