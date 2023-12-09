using Domain.Common;

namespace Domain.Entities
{
    public class GameEntity : BaseEntity<uint>
    {
        public virtual List<CardEntity> Cards { get; set; } = new List<CardEntity>();
        public virtual List<MatchEntity> Matches { get; set; } = new List<MatchEntity>();
    }
}
