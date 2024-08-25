﻿using Ardalis.Specification;

namespace Domain.Game.Specifications.AsNoTracking
{
    public class GameWithAllCardsByIdAsNoTrackingSpecification : SingleResultSpecification<GameAggregate>
    {
        public GameWithAllCardsByIdAsNoTrackingSpecification(Guid id)
        {
            base.Query
                .Include(game => game.Cards)
                .Where(game => game.Id == id)
                .AsNoTracking();
        }
    }
}
