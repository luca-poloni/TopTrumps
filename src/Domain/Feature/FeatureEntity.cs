using Domain.Core;

namespace Domain.Feature
{
    public sealed class FeatureEntity(uint gameId, string name) : BaseEntity<uint>
    {
        public uint GameId { get; } = gameId;
        public string Name { get; private set; } = name;
    }
}
