using Domain.Core;

namespace Domain.CardRound
{
    public sealed class CardRoundEntity(uint cardPlayerId, uint roundId) : BaseEntity<uint>
    {
        public uint CardPlayerId { get; } = cardPlayerId;
        public uint RoundId { get; } = roundId;
    }
}
