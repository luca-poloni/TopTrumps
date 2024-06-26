using Ardalis.SharedKernel;
using Domain.Common;
using Domain.Game.Exceptions;

namespace Domain.Game.Entities
{
    public class RoundEntity : BaseAuditableEntity
    {
        public Guid MatchId { get; set; } = default;
        public MatchEntity Match { get; set; } = null!;
        public List<RoundCardEntity> RoundCards { get; set; } = [];

        public void TakeCards(List<PlayerEntity.PlayerCardEntity> playerCards)
        {
            playerCards.ForEach(playerCard => RoundCards.Add(new RoundCardEntity(playerCard, this)));
        }

        public PlayerEntity WinnerPlayerByFeature(FeatureEntity feature)
        {
            var winnerRoundCard = RoundCards.MaxBy(roundCard => roundCard.PlayerCard.MatchCard.Card.PowerValueByFeature(feature));

            if (winnerRoundCard == default)
                throw new HasNoWinnerRoundCardException();

            return winnerRoundCard.PlayerCard.Player;
        }

        public void GiveCardsToWinnerPlayer(PlayerEntity winnerPlayer)
        {
            winnerPlayer.TakePlayerCards(RoundCards.Select(roundCard => roundCard.PlayerCard).ToList());
        }

        public class RoundCardEntity() : EntityBase<Guid>
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
