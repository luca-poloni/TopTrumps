using Domain.Core;

namespace Domain.Round
{
    public sealed class RoundEntity(uint matchId, uint? winnerPlayerId = default) : BaseEntity<uint>
    {
        public uint MatchId { get; } = matchId;
        public uint? WinnerPlayerId { get; } = winnerPlayerId;
    }
}
