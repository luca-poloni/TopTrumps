using Domain.Game.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class PlayerEntityConfiguration : IEntityTypeConfiguration<PlayerEntity>
    {
        public void Configure(EntityTypeBuilder<PlayerEntity> builder)
        {
            #region Primary Key
            builder
                .HasKey(p => p.Id);
            #endregion

            #region Properties
            builder
                .Property(p => p.Id);

            builder
                .Property(p => p.MatchId)
                .IsRequired();

            builder
                .Property(p => p.Name)
                .IsRequired();

            builder
                .Property(p => p.Created)
                .IsRequired();

            builder
                .Property(p => p.CreatedBy);

            builder
                .Property(p => p.LastModified)
                .IsRequired();

            builder
                .Property(p => p.LastModifiedBy);

            builder
                .Property(p => p.Deleted);

            builder
                .Property(p => p.DeletedBy);
            #endregion

            #region Relationships
            builder
                .HasOne(p => p.Match)
                .WithMany(m => m.Players)
                .HasForeignKey(p => p.MatchId);

            builder
                .HasMany(p => p.PlayerCards)
                .WithOne(pc => pc.Player)
                .HasForeignKey(pc => pc.PlayerId);

            builder
                .HasMany(m => m.WinnerRounds)
                .WithOne(r => r.WinnerPlayer)
                .HasForeignKey(r => r.WinnerPlayerId);

            builder
                .HasMany(p => p.WinnerMatches)
                .WithOne(m => m.WinnerPlayer)
                .HasForeignKey(m => m.WinnerPlayerId);
            #endregion

            #region Filters
            builder
                .HasQueryFilter(p => !p.Deleted.HasValue);
            #endregion
        }
    }
}
