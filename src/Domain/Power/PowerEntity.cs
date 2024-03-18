using Domain.Card;
using Domain.Core;
using Domain.Feature;

namespace Domain.Power
{
    public class PowerEntity : BaseAuditableEntity<ushort>
    {
        public ushort CardId { get; set; } = default;
        public uint FeatureId { get; set; } = default;
        public uint Value { get; set; } = default;
        public CardEntity Card { get; set; } = null!;
        public FeatureEntity Feature { get; set; } = null!;
    }
}
