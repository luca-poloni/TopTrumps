using Domain.Game.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class RoundEntityConfiguration : IEntityTypeConfiguration<RoundEntity>
    {
        public void Configure(EntityTypeBuilder<RoundEntity> builder)
        {
            #region Primary Key
            builder
                .HasKey(r => r.Id);
            #endregion

            #region Properties
            builder
                .Property(r => r.Id);

            builder
                .Property(r => r.MatchId)
                .IsRequired();

            builder
                .Property(r => r.WinnerPlayerId);

            builder
                .Property(r => r.Created)
                .IsRequired();

            builder
                .Property(r => r.CreatedBy);

            builder
                .Property(r => r.LastModified)
                .IsRequired();

            builder
                .Property(r => r.LastModifiedBy);

            builder
                .Property(r => r.Deleted);

            builder
                .Property(r => r.DeletedBy);
            #endregion

            #region Relationships
            builder
                .HasOne(r => r.Match)
                .WithMany(m => m.Rounds)
                .HasForeignKey(r => r.MatchId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(r => r.WinnerPlayer)
                .WithMany(p => p.WinnerRounds)
                .HasForeignKey(r => r.WinnerPlayerId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasMany(r => r.RoundCards)
                .WithOne(rc => rc.Round)
                .HasForeignKey(rc => rc.RoundId)
                .OnDelete(DeleteBehavior.NoAction);
            #endregion

            #region Filters
            builder
                .HasQueryFilter(r => !r.Deleted.HasValue);
            #endregion
        }
    }
}
