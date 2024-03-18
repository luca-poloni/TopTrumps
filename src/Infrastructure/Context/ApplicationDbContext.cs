using Application.Common.Interfaces;
using Domain.Card;
using Domain.Feature;
using Domain.Game;
using Domain.Match;
using Domain.Player;
using Domain.Power;
using Domain.Round;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure.Context
{
    public class ApplicationDbContext(DbContextOptions options) : DbContext(options), IApplicationDbContext
    {
        public DbSet<CardEntity> Cards => Set<CardEntity>();
        public DbSet<FeatureEntity> Features => Set<FeatureEntity>();
        public DbSet<GameEntity> Games => Set<GameEntity>();
        public DbSet<MatchEntity> Matches => Set<MatchEntity>();
        public DbSet<MatchEntity.MatchCardEntity> MatchCards => Set<MatchEntity.MatchCardEntity>();
        public DbSet<PlayerEntity> Players => Set<PlayerEntity>();
        public DbSet<PlayerEntity.PlayerCardEntity> PlayerCards => Set<PlayerEntity.PlayerCardEntity>();
        public DbSet<PowerEntity> Powers => Set<PowerEntity>();
        public DbSet<RoundEntity> Rounds => Set<RoundEntity>();
        public DbSet<RoundEntity.RoundCardEntity> RoundCards => Set<RoundEntity.RoundCardEntity>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
