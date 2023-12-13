using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    internal class PlayerConfiguration : IEntityTypeConfiguration<PlayerEntity>
    {
        public void Configure(EntityTypeBuilder<PlayerEntity> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.MatchId).IsRequired();
            builder.Property(p => p.Name).IsRequired();

            builder.HasOne(p => p.Match)
                   .WithMany(m => m.Players)
                   .HasForeignKey(p => p.MatchId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(p => p.CardPlayers)
                   .WithOne(cp => cp.Player)
                   .HasForeignKey(cp => cp.PlayerId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
