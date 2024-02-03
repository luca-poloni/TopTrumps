using Domain.CardDeck;
using Domain.Core;
using Domain.Round;

namespace Domain.CardRound
{
    public sealed class CardRoundEntity(uint cardDeckId, uint roundId) : BaseEntity<uint>
    {
        public uint CardDeckId { get; } = cardDeckId;
        public uint RoundId { get; } = roundId;
        public CardDeckEntity CardDeck { get; } = null!;
        public RoundEntity Round { get; } = null!;

        public CardRoundEntity(uint cardDeckId, uint roundId, CardDeckEntity cardDeck, RoundEntity round) : this(cardDeckId, roundId)
        {
            CardDeck = cardDeck;
            Round = round;
        }
    }
}
