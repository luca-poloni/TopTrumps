using Application.Common.Interfaces;
using Domain.Entities;
using Domain.Repositores;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    internal class MatchRepository(IApplicationDbContext context) : IMatchRepository
    {
        private readonly IApplicationDbContext _context = context;

        public async Task<MatchEntity> GetById(uint id, CancellationToken cancellationToken)
        {
            var match = await _context.Matches.SingleOrDefaultAsync(match => match.Id == id, cancellationToken);

            if (match == default || match.Id == default)
                throw new ArgumentException("Match cannot be found.");

            return match;
        }
    }
}
