using Application.Common.Interfaces;
using Domain.Entities;
using Domain.Repositores;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    internal class GameRepository(IApplicationDbContext context) : IGameRepository
    {
        private readonly IApplicationDbContext _context = context;

        public async Task<GameEntity> GetById(uint id, CancellationToken cancellationToken)
        {
            var game = await _context.Games.SingleOrDefaultAsync(game => game.Id == id, cancellationToken);

            if (game == default)
                throw new ArgumentException($"Game with id {id} cannot be found.");

            return game;
        }
    }
}
