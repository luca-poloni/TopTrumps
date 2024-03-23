using Domain.Card;
using Domain.Core;
using Domain.Game;
using Domain.Player;
using Domain.Round;

namespace Domain.Match
{
    public class MatchEntity : BaseAuditableEntity
    {
        public Guid GameId { get; set; } = default;
        public bool IsFinish { get; set; } = default;
        public GameEntity Game { get; set; } = null!;
        public List<PlayerEntity> Players { get; set; } = [];
        public List<RoundEntity> Rounds { get; set; } = [];
        public List<MatchCardEntity> MatchCards { get; set; } = [];

        public void TakeShuffledCards()
        {
            Game.ShuffledCards().ForEach(card => MatchCards.Add(new MatchCardEntity(this, card)));
        }

        public void GiveMatchCards()
        {
            var matchCardsPerPlayer = MatchCardsPerPlayer();

            Players.ForEach(player => player.TakeCards(GiveMatchCardsToPlayer(matchCardsPerPlayer)));
        }

        private int MatchCardsPerPlayer()
        {
            return MatchCards.Count / Players.Count;
        }

        private List<MatchCardEntity> GiveMatchCardsToPlayer(int matchCardsPerPlayer)
        {
            var matchCardsToGive = MatchCards.Where(matchCard => !matchCard.Used)?.Take(matchCardsPerPlayer)?.ToList();

            if (matchCardsToGive == default || matchCardsToGive.Count == default)
                throw new HasNoMoreCardsToGiveException();

            matchCardsToGive.ForEach(matchCardToGive => matchCardToGive.Used = true);

            return matchCardsToGive;
        }

        public PlayerEntity WinnerPlayerByCard(MatchCardEntity matchCard)
        {
            var winnerPlayer = Players.SingleOrDefault(player => player.IsWinnerCardBelongPlayer(matchCard));

            if (winnerPlayer == default)
                throw new HasNoWinnerPlayerException();

            return winnerPlayer;
        }

        public void VerifyMatchIsFinish()
        {
            var availablePlayers = AvailablePlayers();

            IsFinish = availablePlayers != default && availablePlayers.Count == 1;
        }

        private List<PlayerEntity> AvailablePlayers()
        {
            return Players.Where(player => player.IsAvailable()).ToList();
        }

        public class MatchCardEntity() : BaseEntity
        {
            public Guid MatchId { get; set; } = default;
            public Guid CardId { get; set; } = default;
            public bool Used { get; set; } = default;
            public MatchEntity Match { get; set; } = null!;
            public CardEntity Card { get; set; } = null!;
            public List<PlayerEntity.PlayerCardEntity> PlayerCards { get; set; } = [];

            public MatchCardEntity(MatchEntity match, CardEntity card) : this()
            {
                Match = match;
                Card = card;
            }
        }
    }
}
