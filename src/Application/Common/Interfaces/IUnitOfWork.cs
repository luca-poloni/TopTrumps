using Domain.Core.Card;
using Domain.Core.Game;

namespace Application.Common.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ICardRepository CardRepository { get; }
        IGameRepository GameRepository { get; }

        Task<int> CommitAsync(CancellationToken cancellationToken);
    }
}
