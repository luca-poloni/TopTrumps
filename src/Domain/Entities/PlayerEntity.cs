using Domain.Common;

namespace Domain.Entities
{
    public class PlayerEntity(uint matchId, string name) : BaseEntity<uint>
    {
        public uint MatchId { get; private set; } = matchId;
        public string Name { get; private set; } = name;
        public virtual MatchEntity Match { get; private set; } = null!;
        public virtual List<CardPlayerEntity> CardPlayers { get; private set; } = [];

        public PlayerEntity(uint matchId, string name, MatchEntity match, List<CardPlayerEntity> cardPlayers) : this(matchId, name)
        {
            Match = match;
            CardPlayers = cardPlayers;
        }

        public bool IsAvailable()
        {
            return CardPlayers.Count > 0;
        }

        public void TakeInitialCards(List<CardPlayerEntity> cardPlayers)
        {
            foreach (var cardPlayer in cardPlayers)
                CardPlayers.Add(cardPlayer);
        }

        public void TakeRoundCards(List<CardPlayerEntity> cardPlayers)
        {
            foreach (var cardPlayer in cardPlayers)
                cardPlayer.Player = this;
        }
    }
}
