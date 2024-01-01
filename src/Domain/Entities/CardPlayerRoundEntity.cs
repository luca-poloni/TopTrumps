using Domain.Common;

namespace Domain.Entities
{
    public class CardPlayerRoundEntity(uint cardPlayerId, uint roundId) : BaseEntity<uint>
    {
        public uint CardPlayerId { get; private set; } = cardPlayerId;
        public uint RoundId { get; private set; } = roundId;
        public virtual CardPlayerEntity CardPlayer { get; private set; } = null!;
        public virtual RoundEntity Round { get; private set; } = null!;

        public CardPlayerRoundEntity(uint cardPlayerId, uint roundId, CardPlayerEntity cardPlayer, RoundEntity round) : this(cardPlayerId, roundId)
        {
            CardPlayer = cardPlayer;
            Round = round;
        }

        public CardPlayerRoundEntity(CardPlayerEntity cardPlayer, RoundEntity round) : this(cardPlayer.Id, round.Id)
        {
            CardPlayer = cardPlayer;
            Round = round;
        }
    }
}
