using Application.Common.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Reflection;

namespace Infrastructure.Context
{
    internal class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options), IApplicationDbContext
    {
        public DbSet<CardEntity> Cards => Set<CardEntity>();
        public DbSet<CardPlayerEntity> CardPlayers => Set<CardPlayerEntity>();
        public DbSet<FeatureEntity> Features => Set<FeatureEntity>();
        public DbSet<GameEntity> Games => Set<GameEntity>();
        public DbSet<MatchEntity> Matches => Set<MatchEntity>();
        public DbSet<PlayerEntity> Players => Set<PlayerEntity>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
