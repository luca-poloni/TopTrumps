using Application.Common.Interfaces;
using Domain.Game;

namespace Infrastructure.Context
{
    internal class UnitOfWork(ApplicationDbContext context, IGameRepository gameRepository) : IUnitOfWork
    {
        private readonly ApplicationDbContext _context = context;
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
