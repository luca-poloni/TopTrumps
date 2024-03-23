using Domain.Card;
using Domain.Core;
using Domain.Feature;
using Domain.Match;

namespace Domain.Game
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
    }
}
