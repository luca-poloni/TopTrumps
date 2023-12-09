using Domain.Common;

namespace Domain.Entities
{
    public class FeatureEntity : BaseEntity<uint>
    {
        public uint CardId { get; set; }
        public string Name { get; set; } = null!;
        public sbyte Value { get; set; }
        public virtual CardEntity Card { get; set; } = null!;

        public bool IsHigher(FeatureEntity? anotherFeature)
        {
            return Value != default && (anotherFeature == default || anotherFeature.Value < Value);
        }
    }
}
