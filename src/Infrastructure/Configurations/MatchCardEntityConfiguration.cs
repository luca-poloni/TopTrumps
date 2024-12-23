using Domain.Game.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class MatchCardEntityConfiguration : IEntityTypeConfiguration<MatchEntity.MatchCardEntity>
    {
        public void Configure(EntityTypeBuilder<MatchEntity.MatchCardEntity> builder)
        {
            #region Primary Key
            builder
                .HasKey(mc => mc.Id);
            #endregion

            #region Properties
            builder
                .Property(mc => mc.Id);

            builder
                .Property(mc => mc.MatchId)
                .IsRequired();

            builder
                .Property(mc => mc.CardId)
                .IsRequired();

            builder
                .Property(mc => mc.Used)
                .IsRequired();

            builder
                .Property(mc => mc.Created)
                .IsRequired();

            builder
                .Property(mc => mc.LastModified)
                .IsRequired();

            builder
                .Property(mc => mc.Deleted);
            #endregion

            #region Relationships
            builder
                .HasOne(mc => mc.Match)
                .WithMany(mc => mc.MatchCards)
                .HasForeignKey(mc => mc.MatchId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(mc => mc.Card)
                .WithMany(c => c.MatchCards)
                .HasForeignKey(mc => mc.CardId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasMany(mc => mc.PlayerCards)
                .WithOne(pc => pc.MatchCard)
                .HasForeignKey(pc => pc.MatchCardId)
                .OnDelete(DeleteBehavior.NoAction);
            #endregion

            #region Filters
            builder
                .HasQueryFilter(mc => !mc.Deleted.HasValue);
            #endregion
        }
    }
}
