using Domain.Game.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class PowerEntityConfiguration : IEntityTypeConfiguration<PowerEntity>
    {
        public void Configure(EntityTypeBuilder<PowerEntity> builder)
        {
            #region Primary Key
            builder.HasKey(p => p.Id);
            #endregion

            #region Properties
            builder.Property(p => p.Value)
                .IsRequired();

            builder.Property(p => p.Created)
                .IsRequired();

            builder.Property(p => p.CreatedBy);

            builder.Property(p => p.LastModified)
                .IsRequired();

            builder.Property(p => p.LastModifiedBy);
            #endregion

            #region Relationships
            builder.HasOne(p => p.Card)
                .WithMany(c => c.Powers)
                .HasForeignKey(p => p.CardId)
                .IsRequired();

            builder.HasOne(p => p.Feature)
                .WithMany(f => f.Powers)
                .HasForeignKey(p => p.FeatureId)
                .IsRequired();
            #endregion
        }
    }
}
