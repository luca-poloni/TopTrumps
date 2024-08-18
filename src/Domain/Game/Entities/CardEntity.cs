using Domain.Game.Exceptions;
using Domain.Primitives;

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
            return Powers.SingleOrDefault(power => power.HasThisFeature(feature))?.Value;
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

        public PowerEntity AddPower(uint value, FeatureEntity feature)
        {
            var power = new PowerEntity
            {
                Value = value,
                Card = this,
                Feature = feature
            };

            Powers.Add(power);

            return power;
        }

        public void RemovePower(PowerEntity power)
        {
            Powers.Remove(power);
        }

        public void RemoveSinglePower()
        {
            RemovePower(SinglePower());
        }

        public PowerEntity SinglePower()
        {
            return Powers
                .SingleOrDefault() ?? throw new SinglePowerNotFoundException();
        }

        public bool HasNoPowers()
        {
            return Powers.Count == 0;
        }
    }
}
