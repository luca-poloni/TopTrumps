﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Game.Entities;

namespace Infrastructure.Configurations
{
    public class PlayerCardEntityConfiguration : IEntityTypeConfiguration<PlayerEntity.PlayerCardEntity>
    {
        public void Configure(EntityTypeBuilder<PlayerEntity.PlayerCardEntity> builder)
        {
            #region Primary Key
            builder
                .HasKey(pc => pc.Id);
            #endregion

            #region Properties
            builder
                .Property(pc => pc.Id);

            builder
                .Property(pc => pc.PlayerId)
                .IsRequired();

            builder
                .Property(pc => pc.MatchCardId)
                .IsRequired();
            #endregion

            #region Relationships
            builder
                .HasOne(pc => pc.Player)
                .WithMany(p => p.PlayerCards)
                .HasForeignKey(pc => pc.PlayerId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(pc => pc.MatchCard)
                .WithMany(mc => mc.PlayerCards)
                .HasForeignKey(pc => pc.MatchCardId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasMany(pc => pc.RoundCards)
                .WithOne(rc => rc.PlayerCard)
                .HasForeignKey(rc => rc.PlayerCardId)
                .OnDelete(DeleteBehavior.NoAction);
            #endregion
        }
    }
}
