using Domain.Common;
using Domain.Core.Card;
using Domain.Core.Feature;

namespace Domain.Core.Power
{
    public class PowerEntity : BaseAuditableEntity
    {
        public Guid CardId { get; set; } = default;
        public Guid FeatureId { get; set; } = default;
        public uint Value { get; set; } = default;
        public CardEntity Card { get; set; } = null!;
        public FeatureEntity Feature { get; set; } = null!;
    }
}
