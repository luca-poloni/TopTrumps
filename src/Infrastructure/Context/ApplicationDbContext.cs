using Application.Common.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure.Context
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options), IApplicationDbContext
    {
        public DbSet<CardEntity> Cards => Set<CardEntity>();
        public DbSet<CardPlayerEntity> CardPlayers => Set<CardPlayerEntity>();
        public DbSet<FeatureEntity> Features => Set<FeatureEntity>();
        public DbSet<GameEntity> Games => Set<GameEntity>();
        public DbSet<MatchEntity> Matches => Set<MatchEntity>();
        public DbSet<PlayerEntity> Players => Set<PlayerEntity>();
        public DbSet<RoundEntity> Rounds => Set<RoundEntity>();
        public DbSet<CardPlayerRoundEntity> CardPlayerRounds => Set<CardPlayerRoundEntity>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
