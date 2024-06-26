using Domain.Common;
using Domain.Game.Exceptions;

namespace Domain.Game.Entities
{
    public class FeatureEntity : BaseAuditableEntity
    {
        public Guid GameId { get; set; } = default;
        public string Name { get; set; } = null!;
        public GameAggregate Game { get; set; } = null!;
        public List<PowerEntity> Powers { get; set; } = [];

        public PowerEntity PowerByCard(CardEntity card)
        {
            var power = Powers.SingleOrDefault(power => power.Card == card);

            if (power == default)
                throw new PowerByCardNotFoundException();

            return power;
        }

        public bool HasThisId(Guid id)
        {
            return Id == id;
        }

        public void Update(string name)
        {
            Name = name;
        }
    }
}
