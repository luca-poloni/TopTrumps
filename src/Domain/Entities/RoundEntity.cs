using Domain.Common;
using Domain.Exceptions;

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
            var winnerCardPlayer = default(CardPlayerEntity);
            var winnerFeature = default(FeatureEntity);

            foreach (var cardPlayerRound in CardPlayerRounds)
            {
                var feature = GetCardFeature(cardPlayerRound, featureName);

                if (feature == default)
                    continue;

                if (GetWinnerFeature(winnerFeature, feature))
                {
                    winnerFeature = feature;
                    winnerCardPlayer = cardPlayerRound.CardPlayer;
                }
            }

            if (winnerCardPlayer == default || winnerFeature  == default || HasMoreThanOneWinnerCard(winnerFeature))
                throw new HasNoWinnerCardException();

            return winnerCardPlayer;
        }

        private static FeatureEntity? GetCardFeature(CardPlayerRoundEntity cardPlayerRound, string featureName)
        {
            return cardPlayerRound?.CardPlayer?.Card?.Features.SingleOrDefault(feature => feature.Name == featureName);
        }

        private static bool GetWinnerFeature(FeatureEntity? winnerFeature, FeatureEntity feature)
        {
            return feature.Value != default && (winnerFeature == default || winnerFeature.Value < feature.Value);
        }

        private bool HasMoreThanOneWinnerCard(FeatureEntity winnerFeature)
        {
            return CardPlayerRounds.Count(card => card?.CardPlayer?.Card?.Features.SingleOrDefault(feature => feature.Value == winnerFeature.Value)?.Value > 1) > 1;
        }
    }
}
