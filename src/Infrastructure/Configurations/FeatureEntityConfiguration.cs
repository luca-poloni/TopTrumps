using Domain.Feature;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Infrastructure.Configurations
{
    public class FeatureEntityConfiguration : IEntityTypeConfiguration<FeatureEntity>
    {
        public void Configure(EntityTypeBuilder<FeatureEntity> builder)
        {
            #region Primary Key
            builder.HasKey(f => f.Id);
            #endregion

            #region Properties
            builder.Property(f => f.Name)
                .IsRequired();

            builder.Property(f => f.Created)
                .IsRequired();

            builder.Property(f => f.CreatedBy);

            builder.Property(f => f.LastModified)
                .IsRequired();

            builder.Property(f => f.LastModifiedBy);
            #endregion

            #region Relationships
            builder.HasOne(f => f.Game)
                .WithMany(g => g.Features)
                .HasForeignKey(f => f.GameId)
                .IsRequired();

            builder.HasMany(f => f.Powers)
                .WithOne(p => p.Feature)
                .HasForeignKey(p => p.FeatureId)
                .OnDelete(DeleteBehavior.Restrict); 
            #endregion
        }
    }
}
