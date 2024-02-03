using Domain.CardRound;
using Domain.Core;
using Domain.Match;
using Domain.Player;

namespace Domain.Round
{
    public sealed class RoundEntity(uint matchId, uint? winnerPlayerId = default) : BaseEntity<uint>
    {
        public uint MatchId { get; } = matchId;
        public uint? WinnerPlayerId { get; private set; } = winnerPlayerId;
        public MatchEntity Match { get; } = null!;
        public List<CardRoundEntity> CardRounds { get; } = [];
        public PlayerEntity? WinnerPlayer { get; private set; } = null;

        public RoundEntity(uint matchId, uint? winnerPlayerId, MatchEntity match, List<CardRoundEntity> cardRounds, PlayerEntity? winnerPlayer) : this(matchId, winnerPlayerId)
        {
            Match = match;
            CardRounds = cardRounds;
            WinnerPlayer = winnerPlayer;
        }
    }
}
