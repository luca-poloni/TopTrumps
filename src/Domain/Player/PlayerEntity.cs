using Domain.Core;
using Domain.Match;
using Domain.Round;

namespace Domain.Player
{
    public class PlayerEntity : BaseAuditableEntity<uint>
    {
        public uint MatchId { get; set; } = default;
        public string Name { get; set; } = string.Empty;
        public MatchEntity Match { get; set; } = null!;
        public List<PlayerCardEntity> PlayerCards { get; set; } = [];

        public bool IsAvailable()
        {
            return PlayerCards.Count > 0;
        }

        public bool IsWinnerCardBelongPlayer(MatchEntity.MatchCardEntity matchCard)
        {
            return PlayerCards.Any(cardPlayer => cardPlayer.MatchCard == matchCard);
        }

        public void TakeCards(List<MatchEntity.MatchCardEntity> matchCards)
        {
            matchCards.ForEach(card => PlayerCards.Add(new PlayerCardEntity(this, card)));
        }

        public void TakePlayerCards(List<PlayerCardEntity> playerCards)
        {
            playerCards.ForEach(cardPlayer => cardPlayer.ChangePlayerTo(this));
        }

        public class PlayerCardEntity() : BaseEntity<uint>
        {
            public uint PlayerId { get; set; } = default;
            public uint MatchCardId { get; set; } = default;
            public PlayerEntity Player { get; set; } = null!;
            public MatchEntity.MatchCardEntity MatchCard { get; set; } = null!;
            public List<RoundEntity.RoundCardEntity> RoundCards { get; set; } = [];

            public PlayerCardEntity(PlayerEntity player, MatchEntity.MatchCardEntity matchCard) : this()
            {
                Player = player;
                MatchCard = matchCard;
            }

            public void ChangePlayerTo(PlayerEntity player)
            {
                Player = player;
            }
        }
    }
}
