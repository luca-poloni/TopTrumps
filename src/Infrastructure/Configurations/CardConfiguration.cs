using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class CardEntityConfiguration : IEntityTypeConfiguration<CardEntity>
    {
        public void Configure(EntityTypeBuilder<CardEntity> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id).IsRequired();
            builder.Property(c => c.GameId).IsRequired();
            builder.Property(c => c.Name).IsRequired();
            builder.Property(c => c.Image).IsRequired();
            builder.Property(c => c.IsTopTrumps).IsRequired();

            builder.HasOne(c => c.Game)
                   .WithMany(g => g.Cards)
                   .HasForeignKey(c => c.GameId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(c => c.CardPlayers)
                   .WithOne(cp => cp.Card)
                   .HasForeignKey(cp => cp.CardId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(c => c.Features)
                   .WithOne(f => f.Card)
                   .HasForeignKey(f => f.CardId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
