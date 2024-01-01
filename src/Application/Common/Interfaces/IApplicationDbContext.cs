using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        public DbSet<CardEntity> Cards { get; }
        public DbSet<CardPlayerEntity> CardPlayers { get; }
        public DbSet<FeatureEntity> Features { get; }
        public DbSet<GameEntity> Games { get; }
        public DbSet<MatchEntity> Matches { get; }
        public DbSet<PlayerEntity> Players { get; }
        public DbSet<RoundEntity> Rounds { get; }
        public DbSet<CardPlayerRoundEntity> CardPlayerRounds { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
