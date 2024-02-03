using Domain.Core;

namespace Domain.CardDeck
{
    public sealed class CardDeckEntity(uint cardId, uint playerId) : BaseEntity<uint>
    {
        public uint CardId { get; private set; } = cardId;
        public uint PlayerId { get; private set; } = playerId;
    }
}
