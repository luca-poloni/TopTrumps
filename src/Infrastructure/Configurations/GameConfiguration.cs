using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Infrastructure.Configurations
{
    internal class GameConfiguration : IEntityTypeConfiguration<GameEntity>
    {
        public void Configure(EntityTypeBuilder<GameEntity> builder)
        {
            builder.HasKey(g => g.Id);

            builder.Property(g => g.Id).IsRequired();
            builder.Property(g => g.Name).IsRequired();
            builder.Property(g => g.Description).IsRequired();

            builder.HasMany(g => g.Cards)
                   .WithOne(c => c.Game)
                   .HasForeignKey(c => c.GameId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(g => g.Matches)
                   .WithOne(m => m.Game)
                   .HasForeignKey(m => m.GameId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
