using Domain.Entities;
using Domain.Exceptions;

namespace Domain.ValueObjects
{
    public class RoundVO
    {
        private readonly List<CardPlayerEntity> _cardPlayers;

        public RoundVO(List<CardPlayerEntity> cardPlayers)
        {
            _cardPlayers = cardPlayers;
        }

        public CardPlayerEntity WinnerCard(string featureName)
        {
            var winnerCardPlayer = default(CardPlayerEntity);
            var winnerFeature = default(FeatureEntity);

            foreach (var cardPlayer in _cardPlayers)
            {
                var feature = GetCardFeature(cardPlayer, featureName);

                if (feature == default)
                    continue;

                if (GetWinnerFeature(winnerFeature, feature))
                {
                    winnerFeature = feature;
                    winnerCardPlayer = cardPlayer;
                }
            }

            if (winnerCardPlayer == default || winnerFeature == default || HasMoreThanOneWinnerCard(winnerFeature))
                throw new HasNoWinnerCardException();

            return winnerCardPlayer;
        }

        private static FeatureEntity? GetCardFeature(CardPlayerEntity cardPlayer, string featureName)
        {
            return cardPlayer?.Card?.Features.SingleOrDefault(feature => feature.Name == featureName);
        }

        private static bool GetWinnerFeature(FeatureEntity? winnerFeature, FeatureEntity feature)
        {
            return feature.Value != default && (winnerFeature == default || winnerFeature.Value < feature.Value);
        }

        private bool HasMoreThanOneWinnerCard(FeatureEntity winnerFeature)
        {
            return _cardPlayers.Count(card => card?.Card?.Features.SingleOrDefault(feature => feature.Value == winnerFeature.Value)?.Value > 1) > 1;
        }
    }
}
