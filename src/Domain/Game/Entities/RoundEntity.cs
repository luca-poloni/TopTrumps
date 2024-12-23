using Domain.Common.Primitives;
using Domain.Game.Exceptions;

namespace Domain.Game.Entities
{
    public class RoundEntity : BaseAuditableEntity
    {
        public Guid MatchId { get; set; } = default;
        public Guid? WinnerPlayerId { get; set; } 
        public MatchEntity Match { get; set; } = null!;
        public PlayerEntity? WinnerPlayer { get; set; }
        public List<RoundCardEntity> RoundCards { get; set; } = [];

        public void Update(Guid? winnerPlayerId)
        {
            WinnerPlayerId = winnerPlayerId;
        }

        public void TakeCards(List<PlayerEntity.PlayerCardEntity> playerCards)
        {
            playerCards.ForEach(playerCard => RoundCards.Add(new RoundCardEntity(playerCard, this)));
        }

        public PlayerEntity Winner(FeatureEntity feature)
        {
            var winnerRoundCard = RoundCards.MaxBy(roundCard => roundCard.PlayerCard.MatchCard.Card.PowerValueByFeature(feature));

            if (winnerRoundCard == default)
                throw new HasNoWinnerPlayerException();

            WinnerPlayer = winnerRoundCard.PlayerCard.Player;

            return WinnerPlayer;
        }

        public List<PlayerEntity.PlayerCardEntity> CardsToWinnerPlayer()
        {
            return RoundCards.Select(roundCard => roundCard.PlayerCard).ToList();
        }

        public class RoundCardEntity() : BaseAuditableDateEntity
        {
            public Guid RoundId { get; set; } = default;
            public Guid PlayerCardId { get; set; } = default;
            public RoundEntity Round { get; set; } = null!;
            public PlayerEntity.PlayerCardEntity PlayerCard { get; set; } = null!;

            public RoundCardEntity(PlayerEntity.PlayerCardEntity playerCard, RoundEntity round) : this()
            {
                PlayerCard = playerCard;
                Round = round;
            }
        }
    }
}
