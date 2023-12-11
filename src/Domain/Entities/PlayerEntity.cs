using Domain.Common;
using Domain.Exceptions;

namespace Domain.Entities
{
    public class PlayerEntity : BaseEntity<uint>
    {
        public uint MatchId { get; set; }
        public string Name { get; set; } = null!;
        public virtual MatchEntity Match { get; set; } = null!;
        public virtual List<CardPlayerEntity> CardPlayers { get; set; } = [];

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
