using Domain.Core;

namespace Domain.Round
{
    public class RoundEntity(uint matchId, uint? winnerPlayerId = default) : BaseEntity<uint>
    {
        public uint MatchId { get; private set; } = matchId;
        public uint? WinnerPlayerId { get; private set; } = winnerPlayerId;
    }
}
