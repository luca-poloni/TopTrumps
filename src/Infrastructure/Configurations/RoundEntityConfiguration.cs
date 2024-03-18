using Domain.Round;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class RoundEntityConfiguration : IEntityTypeConfiguration<RoundEntity>
    {
        public void Configure(EntityTypeBuilder<RoundEntity> builder)
        {
            #region Primary Key
            builder.HasKey(r => r.Id);
            #endregion

            #region Properties
            builder.Property(r => r.Created)
                .IsRequired();

            builder.Property(r => r.CreatedBy);

            builder.Property(r => r.LastModified)
                .IsRequired();

            builder.Property(r => r.LastModifiedBy);
            #endregion

            #region Relationships
            builder.HasOne(r => r.Match)
                .WithMany(m => m.Rounds)
                .HasForeignKey(r => r.MatchId)
                .IsRequired();

            builder.HasMany(r => r.RoundCards)
                .WithOne(rc => rc.Round)
                .HasForeignKey(rc => rc.RoundId)
                .OnDelete(DeleteBehavior.Cascade);
            #endregion
        }
    }
}
