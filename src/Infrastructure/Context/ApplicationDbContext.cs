using Domain.Game;
using Domain.Game.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure.Context
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<CardEntity> Cards => Set<CardEntity>();
        public DbSet<FeatureEntity> Features => Set<FeatureEntity>();
        public DbSet<GameAggregate> Games => Set<GameAggregate>();
        public DbSet<MatchEntity> Matches => Set<MatchEntity>();
        public DbSet<MatchEntity.MatchCardEntity> MatchCards => Set<MatchEntity.MatchCardEntity>();
        public DbSet<PlayerEntity> Players => Set<PlayerEntity>();
        public DbSet<PlayerEntity.PlayerCardEntity> PlayerCards => Set<PlayerEntity.PlayerCardEntity>();
        public DbSet<PowerEntity> Powers => Set<PowerEntity>();
        public DbSet<RoundEntity> Rounds => Set<RoundEntity>();
        public DbSet<RoundEntity.RoundCardEntity> RoundCards => Set<RoundEntity.RoundCardEntity>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
