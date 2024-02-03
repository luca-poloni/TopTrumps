using Domain.Core;

namespace Domain.Power
{
    public sealed class PowerEntity(uint cardId, uint featureId, uint value) : BaseEntity<uint>
    {
        public uint CardId { get; } = cardId;
        public uint FeatureId { get; } = featureId;
        public uint Value { get; private set; } = value;
    }
}
