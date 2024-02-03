using Domain.Core;

namespace Domain.Match
{
    public sealed class MatchEntity(uint gameId) : BaseEntity<uint>
    {
        public uint GameId { get; private set; } = gameId;
        public bool IsFinish { get; private set; }
    }
}
