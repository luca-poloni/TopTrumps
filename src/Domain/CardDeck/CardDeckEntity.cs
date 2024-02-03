using Domain.Core;

namespace Domain.CardDeck
{
    public sealed class CardDeckEntity(uint cardId, uint playerId) : BaseEntity<uint>
    {
        public uint CardId { get; } = cardId;
        public uint PlayerId { get; } = playerId;
    }
}
