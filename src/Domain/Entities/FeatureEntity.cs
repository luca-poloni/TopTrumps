using Domain.Common;

namespace Domain.Entities
{
    public class FeatureEntity(uint cardId, string name, sbyte value) : BaseEntity<uint>
    {
        public uint CardId { get; private set; } = cardId;
        public string Name { get; private set; } = name;
        public sbyte Value { get; private set; } = value;
        public virtual CardEntity Card { get; private set; } = null!;

        public FeatureEntity(uint cardId, string name, sbyte value, CardEntity card) : this(cardId, name, value)
        {
            Card = card;
        }

        public bool IsHigher(FeatureEntity? anotherFeature)
        {
            return Value != default && (anotherFeature == default || anotherFeature.Value < Value);
        }
    }
}
