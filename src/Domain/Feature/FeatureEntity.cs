using Domain.Card;
using Domain.Core;
using Domain.Game;
using Domain.Power;

namespace Domain.Feature
{
    public class FeatureEntity : BaseAuditableEntity<uint>
    {
        public uint GameId { get; set; } = default;
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
