using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Configurations
{
    internal class FeatureConfiguration : IEntityTypeConfiguration<FeatureEntity>
    {
        public void Configure(EntityTypeBuilder<FeatureEntity> builder)
        {
            builder.HasKey(f => f.Id);

            builder.Property(f => f.Id).IsRequired();
            builder.Property(f => f.CardId).IsRequired();
            builder.Property(f => f.Name).IsRequired();
            builder.Property(f => f.Value).IsRequired();

            builder.HasOne(f => f.Card)
                   .WithMany(c => c.Features)
                   .HasForeignKey(f => f.CardId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
