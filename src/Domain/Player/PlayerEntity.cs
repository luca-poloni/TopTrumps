using Domain.CardDeck;
using Domain.Core;
using Domain.Match;

namespace Domain.Player
{
    public sealed class PlayerEntity(uint matchId, string name) : BaseEntity<uint>
    {
        public uint MatchId { get; } = matchId;
        public string Name { get; private set; } = name;
        public MatchEntity Match { get; } = null!;
        public List<CardDeckEntity> CardDecks { get; } = [];

        public PlayerEntity(uint matchId, string name, MatchEntity match, List<CardDeckEntity> cardDecks) : this(matchId, name)
        {
            Match = match;
            CardDecks = cardDecks;
        }
    }
}
