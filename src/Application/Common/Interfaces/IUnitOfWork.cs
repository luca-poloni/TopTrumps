using Domain.Core.Card;
using Domain.Core.Feature;
using Domain.Core.Game;

namespace Application.Common.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ICardRepository CardRepository { get; }
        IFeatureRepository FeatureRepository { get; }
        IGameRepository GameRepository { get; }

        Task<int> CommitAsync(CancellationToken cancellationToken);
    }
}
