using Application.Common.Interfaces;
using Domain.Entities;
using Domain.Repositores;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Repositories
{
    internal class RoundRepository(IApplicationDbContext context) : IRoundRepository
    {
        private readonly IApplicationDbContext _context = context;

        public async Task<RoundEntity> GetById(uint id, CancellationToken cancellationToken)
        {
            var round = await _context.Rounds.SingleOrDefaultAsync(round => round.Id == id, cancellationToken);

            if (round == default)
                throw new ArgumentException($"Round with id {id} cannot be found.");

            return round;
        }
    }
}
