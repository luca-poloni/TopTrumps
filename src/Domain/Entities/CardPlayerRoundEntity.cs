using Domain.Common;

namespace Domain.Entities
{
    public class CardPlayerRoundEntity : BaseEntity<uint>
    {
        public uint CardPlayerId { get; set; }
        public uint RoundId { get; set; }
        public virtual CardPlayerEntity CardPlayer { get; set; } = null!;
        public virtual RoundEntity Round { get; set; } = null!;
    }
}
