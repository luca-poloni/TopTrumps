using Application.Common.Interfaces;
using Domain.Entities;
using Domain.Repositores;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    internal class CardPlayerRepository(IApplicationDbContext context) : ICardPlayerRepository
    {
        private readonly IApplicationDbContext _context = context;

        public async Task<CardPlayerEntity> GetById(uint id, CancellationToken cancellationToken)
        {
            var cardPlayer = await _context.CardPlayers.SingleOrDefaultAsync(cardPlayer => cardPlayer.Id == id, cancellationToken);

            if (cardPlayer == default)
                throw new ArgumentException($"CardPlayer with id {id} cannot be found.");

            return cardPlayer;
        }
    }
}
