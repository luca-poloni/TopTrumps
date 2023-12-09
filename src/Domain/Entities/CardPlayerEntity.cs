using Domain.Common;

namespace Domain.Entities
{
    public class CardPlayerEntity : BaseEntity<uint>
    {
        public uint CardId { get; set; }
        public uint PlayerId { get; set; }
        public virtual CardEntity Card { get; set; } = null!;
        public virtual PlayerEntity Player { get; set; } = null!;
    }
}
