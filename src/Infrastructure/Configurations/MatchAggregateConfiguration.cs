using Domain.Game.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class MatchAggregateConfiguration : IEntityTypeConfiguration<MatchEntity>
    {
        public void Configure(EntityTypeBuilder<MatchEntity> builder)
        {
            #region Primary Key
            builder
                .HasKey(m => m.Id);
            #endregion

            #region Properties
            builder
                .Property(m => m.Id);

            builder
                .Property(m => m.GameId)
                .IsRequired();

            builder
                .Property(m => m.IsFinish)
                .IsRequired();

            builder
                .Property(m => m.Created)
                .IsRequired();

            builder
                .Property(m => m.CreatedBy);

            builder
                .Property(m => m.LastModified)
                .IsRequired();

            builder
                .Property(m => m.LastModifiedBy);
            #endregion

            #region Relationships
            builder
                .HasOne(m => m.Game)
                .WithMany(g => g.Matches)
                .HasForeignKey(m => m.GameId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasMany(m => m.Players)
                .WithOne(p => p.Match)
                .HasForeignKey(p => p.MatchId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasMany(m => m.Rounds)
                .WithOne(r => r.Match)
                .HasForeignKey(r => r.MatchId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasMany(m => m.MatchCards)
                .WithOne(mc => mc.Match)
                .HasForeignKey(mc => mc.MatchId)
                .OnDelete(DeleteBehavior.NoAction);
            #endregion
        }
    }
}
