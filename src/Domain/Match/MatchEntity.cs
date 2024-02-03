using Domain.Core;
using Domain.Game;
using Domain.Player;
using Domain.Round;

namespace Domain.Match
{
    public sealed class MatchEntity(uint gameId) : BaseEntity<uint>
    {
        public uint GameId { get; } = gameId;
        public bool IsFinish { get; private set; }
        public GameEntity Game { get; } = null!;
        public List<PlayerEntity> Players { get; set; } = [];
        public List<RoundEntity> Rounds { get; set; } = [];

        public MatchEntity(uint gameId, bool isFinish, GameEntity game, List<PlayerEntity> players, List<RoundEntity> rounds) : this(gameId)
        {
            IsFinish = isFinish;
            Game = game;
            Players = players;
            Rounds = rounds;
        }
    }
}
