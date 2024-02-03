using Domain.Core;
using Domain.Game;

namespace Domain.Card
{
    public class CardEntity(uint gameId, string name, byte[] image, bool isTopTrumps) : BaseEntity<uint>
    {
        public uint GameId { get; private set; } = gameId;
        public string Name { get; private set; } = name;
        public byte[] Image { get; private set; } = image;
        public bool IsTopTrumps { get; private set; } = isTopTrumps;
        public GameEntity Game { get; } = null!;
    }
}
