using Domain.Common;
using Domain.Exceptions;

namespace Domain.Entities
{
    public class MatchEntity(uint gameId) : BaseEntity<uint>
    {
        public uint GameId { get; private set; } = gameId;
        public bool IsFinish { get; private set; }
        public virtual GameEntity Game { get; private set; } = null!;
        public virtual List<PlayerEntity> Players { get; private set; } = [];
        public virtual List<RoundEntity> Rounds { get; private set; } = [];

        public MatchEntity(uint gameId, GameEntity game, List<PlayerEntity> players, List<RoundEntity> rounds) : this(gameId)
        {
            Game = game;
            Players = players;
            Rounds = rounds;
        }

        public MatchEntity(GameEntity game) : this(game.Id)
        {
            Game = game;
        }

        public void Start()
        {
            if (IsFinish)
                throw new MatchIsFinishException();

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
