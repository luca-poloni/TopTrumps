using Application.Common.Interfaces;
using Domain.Core.Card;
using Domain.Core.Feature;
using Domain.Core.Game;

namespace Infrastructure.Context
{
    internal class UnitOfWork(
        ApplicationDbContext context, 
        ICardRepository cardRepository,
        IFeatureRepository featureRepository,
        IGameRepository gameRepository) 
        : IUnitOfWork
    {
        private readonly ApplicationDbContext _context = context;

        public ICardRepository CardRepository { get; } = cardRepository;
        public IFeatureRepository FeatureRepository { get; } = featureRepository;
        public IGameRepository GameRepository { get; } = gameRepository;

        public async Task<int> CommitAsync(CancellationToken cancellationToken)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
