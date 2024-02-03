using Domain.Core;

namespace Domain.Game
{
    public class GameEntity(string name, string description) : BaseEntity<uint>
    {
        public string Name { get; private set; } = name;
        public string Description { get; private set; } = description;
    }
}
