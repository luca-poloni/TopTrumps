using Domain.Common;

namespace Domain.Entities
{
    public class ThemeEntity : BaseEntity<byte>
    {
        public string Name { get; set; } = null!;
        public byte[] Image { get; set; } = null!;
        public virtual ICollection<GameEntity> Games { get; set; } = new List<GameEntity>();
    }
}
