using Domain.Common;
using Domain.Exceptions;
using Domain.Services;

namespace Domain.Entities
{
    public class MatchEntity(uint gameId) : BaseEntity<uint>
    {
        public uint GameId { get; private set; } = gameId;
        public bool IsFinish { get; private set; }
        public virtual GameEntity Game { get; private set; } = null!;
        public virtual List<PlayerEntity> Players { get; private set; } = [];

        public MatchEntity(uint gameId, GameEntity game, List<PlayerEntity> players) : this(gameId)
        {
            Game = game;
            Players = players;
        }

        public void Play()
        {
            var shuffledCards = Game.ShuffledCards();
            var cardsPerPlayer = CountPlayerCards(shuffledCards);

            GiveCardsForPlayers(shuffledCards, cardsPerPlayer);
        }

        private int CountPlayerCards(List<CardEntity> shuffledCards)
        {
            return shuffledCards.Count / Players.Count;
        }

        private void GiveCardsForPlayers(List<CardEntity> shuffledCards, int cardsPerPlayer)
        {
            foreach (var player in Players)
            {
                var cardsForPlayer = CardsForPlayer(shuffledCards, cardsPerPlayer);
                var playerCards = PlayerCards(cardsForPlayer, player);

                player.TakeCards(playerCards);
                shuffledCards.RemoveAll(cardsForPlayer.Contains);
            }
        }

        public void Move(string featureName)
        {
            if (IsFinish)
                throw new MatchIsFinishException();

            var cardPlayers = TakeCardsOfPlayers(featureName);
            var host = new HostService(cardPlayers);
            var winnerCard = host.WinnerCard(featureName);

            GiveCardsForWinnerPlayer(cardPlayers, winnerCard);

            IsFinish = MatchIsFinish();
        }

        private List<CardPlayerEntity> TakeCardsOfPlayers(string featureName)
        {
            var playerCards = new List<CardPlayerEntity>();

            foreach (var player in AvailablePlayers())
            {
                var playerCard = player.GiveCard(featureName);
                playerCards.Add(playerCard);
            }

            return playerCards;
        }

        private void GiveCardsForWinnerPlayer(List<CardPlayerEntity> playerCards, CardPlayerEntity winnerCard)
        {
            foreach (var player in Players)
            {
                if (winnerCard.Player.Equals(player))
                    player.TakeCards(playerCards);
            }
        }

        private bool MatchIsFinish()
        {
            var availablePlayers = AvailablePlayers();

            return availablePlayers == default || availablePlayers.Count == 1;
        }

        private static List<CardEntity> CardsForPlayer(List<CardEntity> shuffledCards, int cardsPerPlayer)
        {
            return shuffledCards.Take(cardsPerPlayer).ToList();
        }

        private static List<CardPlayerEntity> PlayerCards(List<CardEntity> cardsForPlayer, PlayerEntity player)
        {
            var playerCards = new List<CardPlayerEntity>();

            foreach (var card in cardsForPlayer)
                playerCards.Add(new CardPlayerEntity(card, player));

            return playerCards;
        }

        private List<PlayerEntity> AvailablePlayers()
        {
            return Players.Where(player => player.IsAvailable()).ToList();
        }
    }
}
