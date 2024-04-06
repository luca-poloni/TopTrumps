using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Domain.Core.Game;
using Infrastructure.Context;
using Infrastructure.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    internal class GameRepository(ApplicationDbContext context) : IGameRepository
    {
        private readonly ApplicationDbContext _context = context;

        public void Add(GameEntity game)
        {
            _context.Games.Add(game);
        }

        public void Update(GameEntity game)
        {
            _context.Games.Update(game);
        }

        public void Delete(GameEntity game)
        {
            _context.Games.Remove(game);
        }

        public async Task<GameEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _context.Games
                .WithSpecification(new GameByIdSpecification(id))
                .SingleOrDefaultAsync(cancellationToken);
        }

        public async Task<GameEntity?> GetByIdAsNoTrackingAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _context.Games
                .AsNoTracking()
                .WithSpecification(new GameByIdSpecification(id))
                .SingleOrDefaultAsync(cancellationToken);
        }

        public async Task<IEnumerable<GameEntity>> GetAllAsNoTrackingAsync(CancellationToken cancellationToken)
        {
            return await _context.Games
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }
    }
}
