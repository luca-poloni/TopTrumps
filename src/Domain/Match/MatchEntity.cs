using Domain.Card;
using Domain.CardDeck;
using Domain.Core;
using Domain.Game;
using Domain.Player;
using Domain.Round;

namespace Domain.Match
{
    public sealed class MatchEntity(uint gameId) : BaseEntity<uint>
    {
        public uint GameId { get; } = gameId;
        public bool IsFinish { get; private set; }
        public GameEntity Game { get; } = null!;
        public List<PlayerEntity> Players { get; } = [];
        public List<RoundEntity> Rounds { get; } = [];

        public MatchEntity(uint gameId, bool isFinish, GameEntity game, List<PlayerEntity> players, List<RoundEntity> rounds) : this(gameId)
        {
            IsFinish = isFinish;
            Game = game;
            Players = players;
            Rounds = rounds;
        }

        public void Start()
        {
            if (IsFinish)
                throw new MatchIsFinishException();

            var scrambledCards = Game.ShuffledCards();
            var cardsPerPlayer = CardsPerPlayer(scrambledCards);

            GiveCardsToPlayers(scrambledCards, cardsPerPlayer);
        }

        private int CardsPerPlayer(List<CardEntity> shuffledCards)
        {
            return shuffledCards.Count / Players.Count;
        }

        private void GiveCardsToPlayers(List<CardEntity> shuffledCards, int cardsPerPlayer)
        {
            foreach (var player in Players)
            {
                var cardsForPlayer = CardsForPlayer(shuffledCards, cardsPerPlayer);
                var playerCards = PlayerCards(cardsForPlayer, player);

                player.TakeInitialCards(playerCards);
                shuffledCards.RemoveAll(cardsForPlayer.Contains);
            }
        }

        private static List<CardEntity> CardsForPlayer(List<CardEntity> shuffledCards, int cardsPerPlayer)
        {
            return shuffledCards.Take(cardsPerPlayer).ToList();
        }

        private static List<CardDeckEntity> PlayerCards(List<CardEntity> cardsForPlayer, PlayerEntity player)
        {
            var playerCards = new List<CardDeckEntity>();

            foreach (var card in cardsForPlayer)
                playerCards.Add(new CardDeckEntity(card, player));

            return playerCards;
        }

        public void VerifyMatchIsFinish()
        {
            var availablePlayers = AvailablePlayers();

            IsFinish = availablePlayers == default || availablePlayers.Count == 1;
        }

        private List<PlayerEntity> AvailablePlayers()
        {
            return Players.Where(player => player.IsAvailable()).ToList();
        }
    }
}
