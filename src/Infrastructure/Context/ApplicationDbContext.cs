using Domain.Core.Card;
using Domain.Core.Feature;
using Domain.Core.Game;
using Domain.Core.Match;
using Domain.Core.Player;
using Domain.Core.Power;
using Domain.Core.Round;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure.Context
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
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
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
