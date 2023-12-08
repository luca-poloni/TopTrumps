using Domain.Common;
using Domain.Exceptions;

namespace Domain.Entities
{
    public class PlayerEntity : BaseEntity<uint>
    {
        public uint MatchId { get; set; }
        public string Name { get; set; } = null!;
        public virtual MatchEntity Match { get; set; } = null!;
        public virtual ICollection<CardPlayerEntity> CardPlayers { get; set; } = new List<CardPlayerEntity>();

        public bool IsAvailable()
        {
            return CardPlayers.Any();
        }

        public CardPlayerEntity GiveCard(string featureName)
        {
            var cardPlayer = CardPlayers.SingleOrDefault(cardPlayer => cardPlayer.Card.Name == featureName);

            if (cardPlayer == default)
                throw new CardNotFoundException();

            CardPlayers.Remove(cardPlayer);

            return cardPlayer;
        }

        public void TakeCards(ICollection<CardPlayerEntity> cardPlayers)
        {
            foreach (var cardPlayer in cardPlayers)
                CardPlayers.Add(cardPlayer);
        }
    }
}
