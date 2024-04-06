using Domain.Core.Card;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    internal class CardRepository(ApplicationDbContext context) : ICardRepository
    {
        private readonly ApplicationDbContext _context = context;

        public void Add(CardEntity card)
        {
            _context.Cards.Add(card);
        }

        public void Update(CardEntity card)
        {
            _context.Cards.Update(card);
        }

        public void Delete(CardEntity card)
        {
            _context.Cards.Remove(card);
        }

        public async Task<CardEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _context.Cards.SingleOrDefaultAsync(card => card.Id == id, cancellationToken);
        }

        public async Task<CardEntity?> GetByIdAsNoTrackingAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _context.Cards.AsNoTracking().SingleOrDefaultAsync(card => card.Id == id, cancellationToken);
        }

        public async Task<IEnumerable<CardEntity>> GetAllAsNoTrackingAsync(CancellationToken cancellationToken)
        {
            return await _context.Cards.AsNoTracking().ToListAsync(cancellationToken);
        }
    }
}
