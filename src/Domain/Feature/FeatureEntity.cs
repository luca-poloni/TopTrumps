using Domain.Card;
using Domain.Core;
using Domain.Game;
using Domain.Power;

namespace Domain.Feature
{
    public sealed class FeatureEntity(uint gameId, string name) : BaseEntity<uint>
    {
        public uint GameId { get; } = gameId;
        public string Name { get; private set; } = name;
        public GameEntity Game { get; } = null!;
        public List<PowerEntity> Powers { get; } = [];

        public FeatureEntity(uint gameId, string name, GameEntity game, List<PowerEntity> powers) : this(gameId, name)
        {
            Game = game;
            Powers = powers;
        }

        public PowerEntity? PowerByCard(CardEntity card)
        {
            return Powers.SingleOrDefault(power => power.Card == card);
        }
    }
}
