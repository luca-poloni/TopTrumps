using Domain.Common;
using Domain.Exceptions;

namespace Domain.Entities
{
    public class RoundEntity(uint matchId, uint? winnerPlayerId = default) : BaseEntity<uint>
    {
        public uint MatchId { get; private set; } = matchId;
        public uint? WinnerPlayerId { get; private set; } = winnerPlayerId;
        public virtual MatchEntity Match { get; private set; } = null!;
        public virtual List<CardPlayerRoundEntity> CardPlayerRounds { get; private set; } = [];
        public virtual PlayerEntity? WinnerPlayer { get; private set; } = null;

        public RoundEntity(uint matchId, uint winnerPlayerId, MatchEntity match, List<CardPlayerRoundEntity> cardPlayerRounds, PlayerEntity? winnerPlayer = default) : this(matchId, winnerPlayerId)
        {
            Match = match;
            CardPlayerRounds = cardPlayerRounds;
            WinnerPlayer = winnerPlayer;
        }

        public void TakeCard(uint cardPlayerId)
        {
            var cardPlayer = default(CardPlayerEntity);

            foreach (var player in Match.Players)
            {
                cardPlayer = player.GiveCard(cardPlayerId);

                if (cardPlayer != default)
                    break;
            }

            if (cardPlayer == default)
                throw new CardNotFoundException();

            CardPlayerRounds.Add(new CardPlayerRoundEntity(cardPlayer, this));
        }

        public void Play(string featureName)
        {
            var winnerCard = WinnerCard(featureName);

            foreach (var player in Match.Players)
            {
                if (winnerCard.Player.Equals(player))
                {
                    player.TakeRoundCards(CardPlayerRounds.Select(cardPlayerRound => cardPlayerRound.CardPlayer).ToList());
                    WinnerPlayer = player;
                }
            }

            Match.MatchIsFinish();
        }

        private CardPlayerEntity WinnerCard(string featureName)
        {
            var winnerCardPlayer = default(CardPlayerEntity);
            var winnerFeature = default(FeatureEntity);

            foreach (var playedCard in CardPlayerRounds)
            {
                var feature = playedCard.CardPlayer.Card?.FeatureByName(featureName);

                if (feature == default)
                    continue;

                if (feature.IsHigher(winnerFeature))
                {
                    winnerFeature = feature;
                    winnerCardPlayer = playedCard.CardPlayer;
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

            foreach (var cardPlayer in CardPlayerRounds)
            {
                var winnerFeatureCard = cardPlayer.CardPlayer.Card.WinnerFeatureByValue(winnerFeature.Value);

                if (winnerFeatureCard != default)
                    cardWinnerCount++;
            }

            return cardWinnerCount > 1;
        }
    }
}
