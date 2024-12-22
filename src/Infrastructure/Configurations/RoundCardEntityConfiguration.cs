using Domain.Game.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class RoundCardEntityConfiguration : IEntityTypeConfiguration<RoundEntity.RoundCardEntity>
    {
        public void Configure(EntityTypeBuilder<RoundEntity.RoundCardEntity> builder)
        {
            #region Primary Key
            builder
                .HasKey(rc => rc.Id);
            #endregion

            #region Properties
            builder
                .Property(rc => rc.Id);

            builder
                .Property(rc => rc.RoundId)
                .IsRequired();

            builder
                .Property(rc => rc.PlayerCardId)
                .IsRequired();
            #endregion

            #region Relationships
            builder
                .HasOne(rc => rc.Round)
                .WithMany(r => r.RoundCards)
                .HasForeignKey(rc => rc.RoundId)
                .HasForeignKey(rc => rc.RoundId)
                .OnDelete(DeleteBehavior.NoAction);


            builder
                .HasOne(rc => rc.PlayerCard)
                .WithMany(c => c.RoundCards)
                .HasForeignKey(rc => rc.PlayerCardId)
                .OnDelete(DeleteBehavior.NoAction);
            #endregion
        }
    }
}
