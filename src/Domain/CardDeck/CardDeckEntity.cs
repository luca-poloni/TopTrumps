using Domain.Card;
using Domain.CardRound;
using Domain.Core;
using Domain.Player;

namespace Domain.CardDeck
{
    public sealed class CardDeckEntity(uint cardId, uint playerId) : BaseEntity<uint>
    {
        public uint CardId { get; } = cardId;
        public uint PlayerId { get; } = playerId;
        public CardEntity Card { get; } = null!;
        public PlayerEntity Player { get; } = null!;
        public List<CardRoundEntity> CardRounds { get; } = [];

        public CardDeckEntity(uint cardId, uint playerId, CardEntity card, PlayerEntity player, List<CardRoundEntity> cardRounds) : this(cardId, playerId)
        {
            Card = card;
            Player = player;
            CardRounds = cardRounds;
        }
    }
}
