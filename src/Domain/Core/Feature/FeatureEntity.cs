using Domain.Common;
using Domain.Core.Card;
using Domain.Core.Game;
using Domain.Core.Power;

namespace Domain.Core.Feature
{
    public class FeatureEntity : BaseAuditableEntity
    {
        public Guid GameId { get; set; } = default;
        public string Name { get; set; } = string.Empty;
        public GameEntity Game { get; set; } = null!;
        public List<PowerEntity> Powers { get; set; } = [];

        public PowerEntity PowerByCard(CardEntity card)
        {
            var power = Powers.SingleOrDefault(power => power.Card == card);

            if (power == default)
                throw new PowerByCardNotFoundException();

            return power;
        }
    }
}
