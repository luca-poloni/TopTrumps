using Domain.Common;
using Domain.Exceptions;
using Domain.ValueObjects;

namespace Domain.Entities
{
    public class MatchEntity : BaseEntity<uint>
    {
        public uint GameId { get; set; }
        public bool IsFinish { get; set; }
        public virtual GameEntity Game { get; set; } = null!;
        public virtual List<PlayerEntity> Players { get; set; } = [];

        public void Play()
        {
            var shuffledCards = Game.ShuffledCards();
            var cardsPerPlayer = CountPlayerCards(shuffledCards);

            foreach (var player in Players)
            {
                var cardsForPlayer = CardsForPlayer(shuffledCards, cardsPerPlayer);
                var playerCards = PlayerCards(cardsForPlayer, player);

                player.TakeCards(playerCards);
                shuffledCards.RemoveAll(cardsForPlayer.Contains);
            }
        }

        private int CountPlayerCards(List<CardEntity> shuffledCards)
        {
            return shuffledCards.Count / Players.Count;
        }

        private static List<CardEntity> CardsForPlayer(List<CardEntity> shuffledCards, int cardsPerPlayer)
        {
            return shuffledCards.Take(cardsPerPlayer).ToList();
        }

        private static List<CardPlayerEntity> PlayerCards(List<CardEntity> cardsForPlayer, PlayerEntity player)
        {
            var playerCards = new List<CardPlayerEntity>();

            foreach (var card in cardsForPlayer)
                playerCards.Add(new CardPlayerEntity { Card = card, Player = player });

            return playerCards;
        }

        public void Move(string featureName)
        {
            if (IsFinish)
                throw new MatchIsFinishException();

            var availablePlayers = AvailablePlayers();
            var playerCards = new List<CardPlayerEntity>();

            foreach (var player in availablePlayers)
            {
                var playerCard = player.GiveCard(featureName);

                playerCards.Add(playerCard);
            }

            var round = new RoundVO(playerCards);
            var winnerCard = round.WinnerCard(featureName);

            foreach (var player in Players)
            {
                if (player.CardPlayers.Contains(winnerCard))
                    player.TakeCards(playerCards);
            }

            IsFinish = MatchIsFinish();
        }

        private List<PlayerEntity> AvailablePlayers()
        {
            return Players.Where(player => player.IsAvailable()).ToList();
        }

        private bool MatchIsFinish()
        {
            var availablePlayers = AvailablePlayers();

            return availablePlayers == default || availablePlayers.Count == 1;
        }
    }
}
