using Domain.Game;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class GameAggregateConfiguration : IEntityTypeConfiguration<GameAggregate>
    {
        public void Configure(EntityTypeBuilder<GameAggregate> builder)
        {
            #region Primary Key
            builder
                .HasKey(g => g.Id);
            #endregion

            #region Properties
            builder
                .Property(g => g.Id);

            builder
                .Property(g => g.Name)
                .IsRequired();

            builder
                .Property(g => g.Description)
                .IsRequired();

            builder
                .Property(g => g.Created)
                .IsRequired();

            builder
                .Property(g => g.CreatedBy);

            builder
                .Property(g => g.LastModified)
                .IsRequired();

            builder
                .Property(g => g.LastModifiedBy);
            #endregion

            #region Relationships
            builder
                .HasMany(g => g.Cards)
                .WithOne(c => c.Game)
                .HasForeignKey(c => c.GameId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasMany(g => g.Features)
                .WithOne(f => f.Game)
                .HasForeignKey(f => f.GameId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasMany(g => g.Matches)
                .WithOne(m => m.Game)
                .HasForeignKey(m => m.GameId)
                .OnDelete(DeleteBehavior.NoAction);
            #endregion
        }
    }
}
