using Domain.CardDeck;
using Domain.Core;
using Domain.Game;
using Domain.Power;

namespace Domain.Card
{
    public sealed class CardEntity(uint gameId, string name, byte[] image, bool isTopTrumps) : BaseEntity<uint>
    {
        public uint GameId { get; } = gameId;
        public string Name { get; private set; } = name;
        public byte[] Image { get; private set; } = image;
        public bool IsTopTrumps { get; private set; } = isTopTrumps;
        public GameEntity Game { get; } = null!;
        public List<CardDeckEntity> CardDecks { get; } = [];
        public List<PowerEntity> Powers { get; } = [];

        public CardEntity(uint gameId, string name, byte[] image, bool isTopTrumps, GameEntity game, List<CardDeckEntity> cardDecks, List<PowerEntity> powers) : this(gameId, name, image, isTopTrumps)
        {
            Game = game;
            CardDecks = cardDecks;
            Powers = powers;
        }
    }
}
