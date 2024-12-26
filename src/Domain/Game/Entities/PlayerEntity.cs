using Domain.Common.Primitives;
using Domain.Game.Exceptions;

namespace Domain.Game.Entities
{
    public class PlayerEntity : BaseAuditableEntity
    {
        public Guid MatchId { get; set; } = default;
        public string Name { get; set; } = null!;
        public MatchEntity Match { get; set; } = null!;
        public List<PlayerCardEntity> PlayerCards { get; set; } = [];
        public List<RoundEntity> WinnerRounds { get; set; } = [];
        public List<MatchEntity> WinnerMatches { get; set; } = [];

        public void Update(string name)
        {
            Name = name;
        }

        public bool IsAvailable()
        {
            return PlayerCards.Count > 0;
        }

        public bool IsNotAvailable()
        {
            return !IsAvailable();
        }

        public bool IsWinnerCardBelongPlayer(MatchEntity.MatchCardEntity matchCard)
        {
            return PlayerCards.Any(cardPlayer => cardPlayer.MatchCard == matchCard);
        }

        public void TakeMatchCards(List<MatchEntity.MatchCardEntity> matchCards)
        {
            matchCards.ForEach(card => PlayerCards.Add(new PlayerCardEntity(this, card)));
        }

        public void TakePlayerCards(List<PlayerCardEntity> playerCards)
        {
            PlayerCards.AddRange(playerCards);
        }

        public PlayerCardEntity PickUpPlayerCard()
        {
            var playerCard = PlayerCards.SingleOrDefault() ?? throw new SinglePlayerCardNotFoundException();

            PlayerCards.Remove(playerCard);

            return playerCard;
        }

        public class PlayerCardEntity() : BaseAuditableDateEntity
        {
            public Guid PlayerId { get; set; } = default;
            public Guid MatchCardId { get; set; } = default;
            public PlayerEntity Player { get; set; } = null!;
            public MatchEntity.MatchCardEntity MatchCard { get; set; } = null!;
            public List<RoundEntity.RoundCardEntity> RoundCards { get; set; } = [];

            public PlayerCardEntity(PlayerEntity player, MatchEntity.MatchCardEntity matchCard) : this()
            {
                Player = player;
                MatchCard = matchCard;
            }
        }
    }
}
