using Domain.Common;
using Domain.Exceptions;

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

        public CardPlayerEntity GiveCard(string featureName)
        {
            var cardPlayer = CardPlayers.SingleOrDefault(cardPlayer => cardPlayer.Card.FeatureByName(featureName) != default);

            if (cardPlayer == default)
                throw new CardNotFoundException();

            CardPlayers.Remove(cardPlayer);

            return cardPlayer;
        }

        public void TakeCards(List<CardPlayerEntity> cardPlayers)
        {
            foreach (var cardPlayer in cardPlayers)
                CardPlayers.Add(cardPlayer);
        }
    }
}
