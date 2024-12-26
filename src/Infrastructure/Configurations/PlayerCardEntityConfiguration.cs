using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Game.Entities;

namespace Infrastructure.Configurations
{
    public class PlayerCardEntityConfiguration : IEntityTypeConfiguration<PlayerEntity.PlayerCardEntity>
    {
        public void Configure(EntityTypeBuilder<PlayerEntity.PlayerCardEntity> builder)
        {
            #region Primary Key
            builder
                .HasKey(pc => pc.Id);
            #endregion

            #region Properties
            builder
                .Property(pc => pc.Id);

            builder
                .Property(pc => pc.PlayerId)
                .IsRequired();

            builder
                .Property(pc => pc.MatchCardId)
                .IsRequired();

            builder
                .Property(pc => pc.Created)
                .IsRequired();

            builder
                .Property(pc => pc.LastModified)
                .IsRequired();

            builder
                .Property(pc => pc.Deleted);
            #endregion

            #region Relationships
            builder
                .HasOne(pc => pc.Player)
                .WithMany(p => p.PlayerCards)
                .HasForeignKey(pc => pc.PlayerId);

            builder
                .HasOne(pc => pc.MatchCard)
                .WithMany(mc => mc.PlayerCards)
                .HasForeignKey(pc => pc.MatchCardId);

            builder
                .HasMany(pc => pc.RoundCards)
                .WithOne(rc => rc.PlayerCard)
                .HasForeignKey(rc => rc.PlayerCardId);
            #endregion

            #region Filters
            builder
                .HasQueryFilter(pc => !pc.Deleted.HasValue);
            #endregion
        }
    }
}
