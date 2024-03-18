using Domain.Card;
using Domain.Feature;
using Domain.Game;
using Domain.Match;
using Domain.Player;
using Domain.Power;
using Domain.Round;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        public DbSet<CardEntity> Cards { get; }
        public DbSet<FeatureEntity> Features { get; }
        public DbSet<GameEntity> Games { get; }
        public DbSet<MatchEntity> Matches { get; }
        public DbSet<MatchEntity.MatchCardEntity> MatchCards { get; }
        public DbSet<PlayerEntity> Players { get; }
        public DbSet<PlayerEntity.PlayerCardEntity> PlayerCards { get; }
        public DbSet<PowerEntity> Powers { get; }
        public DbSet<RoundEntity> Rounds { get; }
        public DbSet<RoundEntity.RoundCardEntity> RoundCards { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
