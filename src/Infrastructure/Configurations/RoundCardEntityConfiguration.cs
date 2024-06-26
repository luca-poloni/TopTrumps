using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Game.Entities;

namespace Infrastructure.Configurations
{
    public class RoundCardEntityConfiguration : IEntityTypeConfiguration<RoundEntity.RoundCardEntity>
    {
        public void Configure(EntityTypeBuilder<RoundEntity.RoundCardEntity> builder)
        {
            #region Primary Key
            builder.HasKey(rc => rc.Id);
            #endregion

            #region Relationships
            builder.HasOne(rc => rc.Round)
                .WithMany(r => r.RoundCards)
                .HasForeignKey(rc => rc.RoundId)
                .IsRequired();

            builder.HasOne(rc => rc.PlayerCard)
                .WithMany()
                .HasForeignKey(rc => rc.PlayerCardId)
                .IsRequired();
            #endregion
        }
    }
}
