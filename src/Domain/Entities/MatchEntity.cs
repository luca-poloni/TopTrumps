using Domain.Common;

namespace Domain.Entities
{
    public class MatchEntity : BaseEntity<uint>
    {
        public uint GameId { get; set; }
        public virtual GameEntity Game { get; set; } = null!;
        public virtual ICollection<PlayerEntity> Players { get; set; } = new List<PlayerEntity>();
        public virtual ICollection<RoundEntity> Rounds { get; set; } = new List<RoundEntity>();
    }
}
