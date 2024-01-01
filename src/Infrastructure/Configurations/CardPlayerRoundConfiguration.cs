using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    internal class CardPlayerRoundConfiguration : IEntityTypeConfiguration<CardPlayerRoundEntity>
    {
        public void Configure(EntityTypeBuilder<CardPlayerRoundEntity> builder)
        {
            builder.HasKey(cpr => cpr.Id);

            builder.Property(cpr => cpr.Id)
                   .IsRequired();

            builder.Property(cpr => cpr.CardPlayerId)
                   .IsRequired();

            builder.Property(cpr => cpr.RoundId)
                   .IsRequired();

            builder.HasOne(cpr => cpr.CardPlayer)
                   .WithMany(cp => cp.CardPlayerRounds)
                   .HasForeignKey(cpr => cpr.CardPlayerId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
