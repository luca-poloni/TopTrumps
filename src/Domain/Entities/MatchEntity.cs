using Domain.Common;
using Domain.Exceptions;
using Domain.ValueObjects;

namespace Domain.Entities
{
    public class MatchEntity : BaseEntity<uint>
    {
        public uint GameId { get; set; }
        public virtual GameEntity Game { get; set; } = null!;
        public virtual List<PlayerEntity> Players { get; set; } = [];

        public void Play()
        {
            var shuffledCards = Game.GetShuffledCards();
            var cardsPerPlayer = CountPlayerCards(shuffledCards);

            foreach (var player in Players)
            {
                var cardsForPlayer = GetCardsForPlayer(shuffledCards, cardsPerPlayer);
                var playerCards = GetPlayerCards(cardsForPlayer, player);

                player.TakeCards(playerCards);
                shuffledCards.RemoveAll(cardsForPlayer.Contains);
            }
        }

        private int CountPlayerCards(List<CardEntity> shuffledCards)
        {
            return shuffledCards.Count / Players.Count;
        }

        private static List<CardEntity> GetCardsForPlayer(List<CardEntity> shuffledCards, int cardsPerPlayer)
        {
            var cardsForPlayer = shuffledCards.Take(cardsPerPlayer)?.ToList();

            if (cardsForPlayer == default || !cardsForPlayer.Any())
                throw new CardsForPlayerNotFoundException();

            return cardsForPlayer;
        }

        private static List<CardPlayerEntity> GetPlayerCards(List<CardEntity> cardsForPlayer, PlayerEntity player)
        {
            var playerCards = new List<CardPlayerEntity>();

            foreach (var card in cardsForPlayer)
                playerCards.Add(new CardPlayerEntity { Card = card, Player = player });

            if (playerCards == default || !playerCards.Any())
                throw new PlayerCardsNotFoundException();

            return playerCards;
        }

        public void Move(string featureName)
        {
            var availablePlayers = GetAvailablePlayers();
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
        }

        private List<PlayerEntity> GetAvailablePlayers()
        {
            var availablePlayers = Players.Where(player => player.IsAvailable())?.ToList();

            if (availablePlayers == default || availablePlayers.Count == 1)
                throw new MatchIsFinishException();

            return availablePlayers;
        }
    }
}
