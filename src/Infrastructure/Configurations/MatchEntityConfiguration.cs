using Domain.Game.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class MatchEntityConfiguration : IEntityTypeConfiguration<MatchEntity>
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
                .Property(m => m.WinnerPlayerId);

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

            builder
                .Property(m => m.Deleted);

            builder
                .Property(m => m.DeletedBy);
            #endregion

            #region Relationships
            builder
                .HasOne(m => m.Game)
                .WithMany(g => g.Matches)
                .HasForeignKey(m => m.GameId);

            builder
                .HasOne(m => m.WinnerPlayer)
                .WithMany(p => p.WinnerMatches)
                .HasForeignKey(m => m.WinnerPlayerId);

            builder
                .HasMany(m => m.Players)
                .WithOne(p => p.Match)
                .HasForeignKey(p => p.MatchId);

            builder
                .HasMany(m => m.Rounds)
                .WithOne(r => r.Match)
                .HasForeignKey(r => r.MatchId);

            builder
                .HasMany(m => m.MatchCards)
                .WithOne(mc => mc.Match)
                .HasForeignKey(mc => mc.MatchId);
            #endregion

            #region Filters
            builder
                .HasQueryFilter(m => !m.Deleted.HasValue);
            #endregion
        }
    }
}
