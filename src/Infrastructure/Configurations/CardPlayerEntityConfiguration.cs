using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Configurations
{
    internal class CardPlayerEntityConfiguration : IEntityTypeConfiguration<CardPlayerEntity>
    {
        public void Configure(EntityTypeBuilder<CardPlayerEntity> builder)
        {
            builder.HasKey(cp => cp.Id);

            builder.HasOne(cp => cp.Card)
                   .WithMany(c => c.CardPlayers)
                   .HasForeignKey(cp => cp.CardId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(cp => cp.Player)
                   .WithMany(p => p.CardPlayers)
                   .HasForeignKey(cp => cp.PlayerId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
