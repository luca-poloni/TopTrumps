using Domain.Common;

namespace Domain.Game.Entities
{
    public class CardEntity : BaseAuditableEntity
    {
        public Guid GameId { get; set; } = default;
        public string Name { get; set; } = null!;
        public bool IsTopTrumps { get; set; } = default;
        public GameAggregate Game { get; set; } = null!;
        public List<PowerEntity> Powers { get; set; } = [];
        public List<MatchEntity.MatchCardEntity> MatchCards { get; set; } = [];

        public uint? PowerValueByFeature(FeatureEntity feature)
        {
            return Powers.SingleOrDefault(power => power.Feature == feature)?.Value;
        }

        public void Update(string name, bool isTopTrumps)
        {
            Name = name;
            IsTopTrumps = isTopTrumps;
        }

        public bool HasThisId(Guid cardId)
        {
            return Id == cardId;
        }
    }
}
