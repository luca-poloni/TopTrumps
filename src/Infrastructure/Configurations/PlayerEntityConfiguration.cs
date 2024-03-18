using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Player;

namespace Infrastructure.Configurations
{
    public class PlayerEntityConfiguration : IEntityTypeConfiguration<PlayerEntity>
    {
        public void Configure(EntityTypeBuilder<PlayerEntity> builder)
        {
            #region Primary Key
            builder.HasKey(p => p.Id);
            #endregion

            #region Properties
            builder.Property(p => p.Name)
                .IsRequired();

            builder.Property(p => p.Created)
                .IsRequired();

            builder.Property(p => p.CreatedBy);

            builder.Property(p => p.LastModified)
                .IsRequired();

            builder.Property(p => p.LastModifiedBy);
            #endregion

            #region Relationships
            builder.HasOne(p => p.Match)
                .WithMany(m => m.Players)
                .HasForeignKey(p => p.MatchId)
                .IsRequired();

            builder.HasMany(p => p.PlayerCards)
                .WithOne(pc => pc.Player)
                .HasForeignKey(pc => pc.PlayerId)
                .OnDelete(DeleteBehavior.Cascade);
            #endregion
        }
    }
}
