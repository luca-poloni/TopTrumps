using Domain.Core;
using Domain.Feature;
using Domain.Game;
using Domain.Match;
using Domain.Power;

namespace Domain.Card
{
    public class CardEntity : BaseAuditableEntity
    {
        public Guid GameId { get; set; } = default;
        public string Name { get; set; } = string.Empty;
        public bool IsTopTrumps { get; set; } = default;
        public GameEntity Game { get; set; } = null!;
        public List<PowerEntity> Powers { get; set; } = [];
        public List<MatchEntity.MatchCardEntity> MatchCards { get; set; } = [];

        public uint? PowerValueByFeature(FeatureEntity feature)
        {
            return Powers.SingleOrDefault(power => power.Feature == feature)?.Value;
        }
    }
}
