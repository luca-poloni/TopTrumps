using Domain.Common;

namespace Domain.Entities
{
    public class RoundEntity : BaseEntity<uint>
    {
        public uint MatchId { get; set; }
        public string Name { get; set; } = null!;
        public virtual MatchEntity Match { get; set; } = null!;
        public virtual ICollection<CardPlayerRoundEntity> CardPlayerRounds { get; set; } = new List<CardPlayerRoundEntity>();

        public CardPlayerEntity WinnerCard(string featureName)
        {
            var winnerCard = CardPlayerRounds.MaxBy(card => card?.CardPlayer?.Card?.Features.SingleOrDefault(feature => feature.Name == featureName)?.Value);

            if (winnerCard == default)
                throw new Exception("Has no winner card.");

            return winnerCard.CardPlayer;
        }
    }
}
