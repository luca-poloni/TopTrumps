using Domain.Common;

namespace Domain.Entities
{
    public class CardEntity : BaseEntity<uint>
    {
        public uint GameId { get; set; }
        public string Name { get; set; } = null!;
        public byte[] Image { get; set; } = null!;
        public bool IsTopTrumps { get; set; }
        public virtual GameEntity Game { get; set; } = null!;
        public virtual List<CardPlayerEntity> CardPlayers { get; set; } = new List<CardPlayerEntity>();
        public virtual List<FeatureEntity> Features { get; set; } = new List<FeatureEntity>();

        public FeatureEntity? FeatureByName(string featureName)
        {
            return Features.SingleOrDefault(feature => feature.Name == featureName);
        }

        public FeatureEntity? WinnerFeatureByValue(sbyte value)
        {
            return Features.SingleOrDefault(feature => feature.Value == value);
        } 
    }
}
