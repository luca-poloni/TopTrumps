﻿using Domain.Game.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class CardEntityConfiguration : IEntityTypeConfiguration<CardEntity>
    {
        public void Configure(EntityTypeBuilder<CardEntity> builder)
        {
            #region Primary Key
            builder
                .HasKey(c => c.Id);
            #endregion

            #region Properties
            builder
                .Property(c => c.Id);

            builder
                .Property(c => c.GameId)
                .IsRequired();

            builder
                .Property(c => c.Name)
                .IsRequired();

            builder
                .Property(c => c.IsTopTrumps)
                .IsRequired();

            builder
                .Property(c => c.Created)
                .IsRequired();

            builder
                .Property(c => c.CreatedBy);

            builder
                .Property(c => c.LastModified)
                .IsRequired();

            builder
                .Property(c => c.LastModifiedBy);

            builder
                .Property(c => c.Deleted);

            builder
                .Property(c => c.DeletedBy);
            #endregion

            #region Relationships
            builder
                .HasOne(c => c.Game)
                .WithMany(g => g.Cards)
                .HasForeignKey(c => c.GameId);

            builder
                .HasMany(c => c.Powers)
                .WithOne(p => p.Card)
                .HasForeignKey(p => p.CardId);

            builder
                .HasMany(c => c.MatchCards)
                .WithOne(cp => cp.Card)
                .HasForeignKey(cp => cp.CardId);
            #endregion

            #region Filters
            builder
                .HasQueryFilter(c => !c.Deleted.HasValue);
            #endregion
        }
    }
}
