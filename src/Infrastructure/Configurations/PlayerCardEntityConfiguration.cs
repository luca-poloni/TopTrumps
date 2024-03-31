using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Core.Player;

namespace Infrastructure.Configurations
{
    public class PlayerCardEntityConfiguration : IEntityTypeConfiguration<PlayerEntity.PlayerCardEntity>
    {
        public void Configure(EntityTypeBuilder<PlayerEntity.PlayerCardEntity> builder)
        {
            #region Primary Key
            builder.HasKey(pc => pc.Id);
            #endregion

            #region Relationships
            builder.HasOne(pc => pc.Player)
                .WithMany(p => p.PlayerCards)
                .HasForeignKey(pc => pc.PlayerId)
                .IsRequired();

            builder.HasOne(pc => pc.MatchCard)
                .WithMany(mc => mc.PlayerCards)
                .HasForeignKey(pc => pc.MatchCardId)
                .IsRequired();

            builder.HasMany(pc => pc.RoundCards)
                .WithOne(rc => rc.PlayerCard)
                .HasForeignKey(rc => rc.PlayerCardId)
                .OnDelete(DeleteBehavior.Cascade);
            #endregion
        }
    }
}
