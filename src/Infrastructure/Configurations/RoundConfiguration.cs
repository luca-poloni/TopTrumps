using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class RoundConfiguration : IEntityTypeConfiguration<RoundEntity>
    {
        public void Configure(EntityTypeBuilder<RoundEntity> builder)
        {
            builder.HasKey(r => r.Id);

            builder.Property(r => r.MatchId).IsRequired();
            builder.Property(r => r.WinnerPlayerId);


            builder.HasOne(r => r.Match)
                   .WithMany(m => m.Rounds)
                   .HasForeignKey(r => r.MatchId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(r => r.WinnerPlayer)
                   .WithMany()
                   .HasForeignKey(r => r.WinnerPlayerId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
