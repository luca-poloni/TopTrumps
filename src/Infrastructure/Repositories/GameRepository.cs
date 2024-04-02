using Domain.Core.Game;
using Infrastructure.Context;
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
            return await _context.Games.AsNoTracking().SingleOrDefaultAsync(game => game.Id == id, cancellationToken);
        }

        public async Task<IEnumerable<GameEntity>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _context.Games.AsNoTracking().ToListAsync(cancellationToken);
        }
    }
}
