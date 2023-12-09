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
                var feature = cardPlayer.Card?.GetFeature(featureName);

                if (feature == default)
                    continue;

                if (feature.IsHigher(winnerFeature))
                {
                    winnerFeature = feature;
                    winnerCardPlayer = cardPlayer;
                }
            }

            if (winnerCardPlayer == default || winnerFeature == default)
                throw new HasNoWinnerCardException();

            if (HasMoreThanOneWinnerCard(winnerFeature))
                throw new HasMoreThanOneWinnerCardException();

            return winnerCardPlayer;
        }

        private bool HasMoreThanOneWinnerCard(FeatureEntity winnerFeature)
        {
            var cardWinnerCount = 0;

            foreach (var cardPlayer in _cardPlayers)
            {
                var winnerFeatureCard = cardPlayer.Card.GetWinnerFeatureByValue(winnerFeature.Value);

                if (winnerFeatureCard != default)
                    cardWinnerCount++;
            }

            return cardWinnerCount > 1;
        }
    }
}
