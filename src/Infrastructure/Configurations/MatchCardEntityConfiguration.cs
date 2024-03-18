using Domain.Match;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class MatchCardEntityConfiguration : IEntityTypeConfiguration<MatchEntity.MatchCardEntity>
    {
        public void Configure(EntityTypeBuilder<MatchEntity.MatchCardEntity> builder)
        {
            #region Primary Key
            builder.HasKey(mc => mc.Id);
            #endregion

            #region Properties
            builder.Property(mc => mc.Used)
                .IsRequired();
            #endregion

            #region Relationships
            builder.HasOne(mc => mc.Match)
                .WithMany(m => m.MatchCards)
                .HasForeignKey(mc => mc.MatchId)
                .IsRequired();

            builder.HasOne(mc => mc.Card)
                .WithMany()
                .HasForeignKey(mc => mc.CardId)
                .IsRequired();

            builder.HasMany(mc => mc.PlayerCards)
                .WithOne(pc => pc.MatchCard)
                .HasForeignKey(pc => pc.MatchCardId)
                .OnDelete(DeleteBehavior.Cascade);
            #endregion

        }
    }
}
