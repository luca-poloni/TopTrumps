using Domain.Core;

namespace Domain.Player
{
    public sealed class PlayerEntity(uint matchId, string name) : BaseEntity<uint>
    {
        public uint MatchId { get; private set; } = matchId;
        public string Name { get; private set; } = name;
    }
}
