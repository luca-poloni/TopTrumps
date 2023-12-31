﻿using Domain.Common;

namespace Domain.Entities
{
    public class CardPlayerEntity(uint cardId, uint playerId) : BaseEntity<uint>
    {
        public uint CardId { get; private set; } = cardId;
        public uint PlayerId { get; private set; } = playerId;
        public virtual CardEntity Card { get; private set; } = null!;
        public virtual PlayerEntity Player { get; set; } = null!;
        public virtual List<CardPlayerRoundEntity> CardPlayerRounds { get; private set; } = [];

        public CardPlayerEntity(uint cardId, uint playerId, CardEntity card, PlayerEntity player, List<CardPlayerRoundEntity> cardPlayerRounds) : this(cardId, playerId)
        {
            Card = card;
            Player = player;
            CardPlayerRounds = cardPlayerRounds;
        }

        public CardPlayerEntity(CardEntity card, PlayerEntity player) : this(card.Id, player.Id)
        {
            Card = card;
            Player = player;
        }
    }
}
