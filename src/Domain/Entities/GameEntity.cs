using Domain.Common;

namespace Domain.Entities
{
    public class GameEntity : BaseEntity<uint>
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public virtual List<CardEntity> Cards { get; set; } = [];
        public virtual List<MatchEntity> Matches { get; set; } = [];

        public List<CardEntity> ShuffledCards()
        {
            return [.. Cards.OrderBy(card => Guid.NewGuid())];
        }
    }
}
