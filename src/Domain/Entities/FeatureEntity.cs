using Domain.Common;

namespace Domain.Entities
{
    public class FeatureEntity(uint cardId, string name, uint value) : BaseEntity<uint>
    {
        public uint CardId { get; private set; } = cardId;
        public string Name { get; private set; } = name;
        public uint Value { get; private set; } = value;
        public virtual CardEntity Card { get; private set; } = null!;

        public FeatureEntity(uint cardId, string name, uint value, CardEntity card) : this(cardId, name, value)
        {
            Card = card;
        }

        public bool IsHigher(FeatureEntity? anotherFeature)
        {
            return Value != default && (anotherFeature == default || anotherFeature.Value < Value);
        }
    }
}
