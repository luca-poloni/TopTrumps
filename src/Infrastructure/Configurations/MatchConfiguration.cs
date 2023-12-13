using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    internal class MatchConfiguration : IEntityTypeConfiguration<MatchEntity>
    {
        public void Configure(EntityTypeBuilder<MatchEntity> builder)
        {
            builder.HasKey(m => m.Id);

            builder.Property(m => m.Id).IsRequired();
            builder.Property(m => m.GameId).IsRequired();
            builder.Property(m => m.IsFinish).IsRequired();

            builder.HasOne(m => m.Game)
                   .WithMany(g => g.Matches)
                   .HasForeignKey(m => m.GameId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(m => m.Players)
                   .WithOne(p => p.Match)
                   .HasForeignKey(p => p.MatchId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
