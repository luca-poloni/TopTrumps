using Domain.Common;

namespace Domain.Entities
{
    public class GameEntity(string name, string description) : BaseEntity<uint>
    {
        public string Name { get; private set; } = name;
        public string Description { get; private set; } = description;
        public virtual List<CardEntity> Cards { get; private set; } = [];
        public virtual List<MatchEntity> Matches { get; private set; } = [];

        public GameEntity(string name, string description, List<CardEntity> cards, List<MatchEntity> matches) : this(name, description)
        {
            Cards = cards;
            Matches = matches;
        }

        public List<CardEntity> ShuffledCards()
        {
            return [.. Cards.OrderBy(card => Guid.NewGuid())];
        }
    }
}
