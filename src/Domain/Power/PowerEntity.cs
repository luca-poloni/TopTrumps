using Domain.Card;
using Domain.Core;
using Domain.Feature;

namespace Domain.Power
{
    public sealed class PowerEntity(uint cardId, uint featureId, uint value) : BaseEntity<uint>
    {
        public uint CardId { get; } = cardId;
        public uint FeatureId { get; } = featureId;
        public uint Value { get; private set; } = value;
        public CardEntity Card { get; } = null!;
        public FeatureEntity Feature { get; } = null!;

        public PowerEntity(uint cardId, uint featureId, uint value, CardEntity card, FeatureEntity feature) : this(cardId, featureId, value)
        {
            Card = card;
            Feature = feature;
        }
    }
}
