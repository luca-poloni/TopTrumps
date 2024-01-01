using Domain.Common;

namespace Domain.Entities
{
    public class CardEntity(uint gameId, string name, byte[] image, bool isTopTrumps) : BaseEntity<uint>
    {
        public uint GameId { get; private set; } = gameId;
        public string Name { get; private set; } = name;
        public byte[] Image { get; private set; } = image;
        public bool IsTopTrumps { get; private set; } = isTopTrumps;
        public virtual GameEntity Game { get; private set; } = null!;
        public virtual List<CardPlayerEntity> CardPlayers { get; private set; } = [];
        public virtual List<FeatureEntity> Features { get; private set; } = [];

        public CardEntity(uint gameId, string name, byte[] image, bool isTopTrumps, GameEntity game, List<CardPlayerEntity> cardPlayers, List<FeatureEntity> features) : this(gameId, name, image, isTopTrumps)
        {
            Game = game;
            CardPlayers = cardPlayers;
            Features = features;
        }

        public FeatureEntity? FeatureByName(string featureName)
        {
            return Features.SingleOrDefault(feature => feature.Name == featureName);
        }

        public FeatureEntity? WinnerFeatureByValue(uint value)
        {
            return Features.SingleOrDefault(feature => feature.Value == value);
        } 
    }
}
