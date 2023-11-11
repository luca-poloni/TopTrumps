using Domain.Common;

namespace Domain.Entities
{
    public class GameEntity : BaseEntity<uint>
    {
        public byte ThemeId { get; set; }
        public virtual ThemeEntity Theme { get; set; } = null!;
        public virtual ICollection<CardEntity> Cards { get; set; } = new List<CardEntity>();
        public virtual ICollection<MatchEntity> Matches { get; set; } = new List<MatchEntity>();
    }
}
