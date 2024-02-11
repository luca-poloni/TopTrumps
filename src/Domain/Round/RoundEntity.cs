using Domain.CardDeck;
using Domain.CardRound;
using Domain.Core;
using Domain.Feature;
using Domain.Match;
using Domain.Player;
using Domain.Power;

namespace Domain.Round
{
    public sealed class RoundEntity(uint matchId, uint? winnerPlayerId = default) : BaseEntity<uint>
    {
        public uint MatchId { get; } = matchId;
        public uint? WinnerPlayerId { get; private set; } = winnerPlayerId;
        public MatchEntity Match { get; } = null!;
        public List<CardRoundEntity> CardRounds { get; } = [];
        public PlayerEntity? WinnerPlayer { get; private set; } = null;

        public RoundEntity(uint matchId, uint? winnerPlayerId, MatchEntity match, List<CardRoundEntity> cardRounds, PlayerEntity? winnerPlayer) : this(matchId, winnerPlayerId)
        {
            Match = match;
            CardRounds = cardRounds;
            WinnerPlayer = winnerPlayer;
        }

        public void TakeCard(CardDeckEntity cardDeck)
        {
            if (IsRoundNotPlayable())
                throw new RoundNotPlayableException();

            if (PlayerIsRepeated(cardDeck))
                throw new RepeatedPlayerException();

            CardRounds.Add(new CardRoundEntity(cardDeck, this));
        }

        public void Play(FeatureEntity feature)
        {
            if (IsRoundNotPlayable())
                throw new RoundNotPlayableException();

            if (IsInsufficientNumberCards())
                throw new InsufficientNumberCardsException();

            var winnerCard = WinnerCard(feature);

            foreach (var player in Match.Players)
            {
                if (winnerCard.Player.Equals(player))
                {
                    player.TakeRoundCards(CardRounds.Select(cardPlayerRound => cardPlayerRound.CardDeck).ToList());
                    WinnerPlayer = player;
                }
            }

            Match.VerifyMatchIsFinish();
        }

        private bool IsRoundNotPlayable()
        {
            return Match.IsFinish || WinnerPlayerId != default;
        }

        private bool IsInsufficientNumberCards()
        {
            return CardRounds.Count <= 1;
        }

        private bool PlayerIsRepeated(CardDeckEntity cardDeck)
        {
            return CardRounds.Any(cardRound => cardRound.CardDeck.Player == cardDeck.Player);
        }

        private CardDeckEntity WinnerCard(FeatureEntity feature)
        {
            var winnerCardDeck = default(CardDeckEntity);
            var winnerPower = default(PowerEntity);

            foreach (var playedCard in CardRounds)
            {
                var power = feature.PowerByCard(playedCard.CardDeck.Card);

                if (power == default)
                    continue;

                if (power.IsHigher(winnerPower))
                {
                    winnerPower = power;
                    winnerCardDeck = playedCard.CardDeck;
                }
            }

            if (winnerCardDeck == default || winnerPower == default)
                throw new HasNoWinnerCardException();

            if (HasMoreThanOneWinnerCard(winnerPower))
                throw new HasMoreThanOneWinnerCardException();

            return winnerCardDeck;
        }

        private bool HasMoreThanOneWinnerCard(PowerEntity winnerPower)
        {
            var cardWinnerCount = 0;

            foreach (var cardPlayer in CardRounds)
            {
                var winnerPowerCard = cardPlayer.CardDeck.Card.WinnerPowerByValue(winnerPower.Value);

                if (winnerPowerCard != default)
                    cardWinnerCount++;
            }

            return cardWinnerCount > 1;
        }
    }
}
