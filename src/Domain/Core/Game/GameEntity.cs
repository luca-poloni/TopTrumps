using Domain.Common;
using Domain.Core.Card;
using Domain.Core.Feature;
using Domain.Core.Match;

namespace Domain.Core.Game
{
    public class GameEntity : BaseAuditableEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<CardEntity> Cards { get; set; } = [];
        public List<FeatureEntity> Features { get; set; } = [];
        public List<MatchEntity> Matches { get; set; } = [];

        public List<CardEntity> ShuffledCards()
        {
            return [.. Cards.OrderBy(card => Guid.NewGuid())];
        }

        public void Update(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
