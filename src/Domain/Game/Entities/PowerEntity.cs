﻿using Domain.Common.Primitives;

namespace Domain.Game.Entities
{
    public class PowerEntity : BaseAuditableEntity
    {
        public Guid CardId { get; set; } = default;
        public Guid FeatureId { get; set; } = default;
        public uint Value { get; set; } = default;
        public CardEntity Card { get; set; } = null!;
        public FeatureEntity Feature { get; set; } = null!;

        public void Update(uint value)
        {
            Value = value;
        }

        public bool HasThisFeature(FeatureEntity feature)
        {
            return Feature == feature;
        }
    }
}
