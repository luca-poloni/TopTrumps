using Domain.Card;
using Domain.Core;
using Domain.Feature;
using Domain.Match;

namespace Domain.Game
{
    public sealed class GameEntity(string name, string description) : BaseEntity<uint>
    {
        public string Name { get; private set; } = name;
        public string Description { get; private set; } = description;
        public List<CardEntity> Cards { get; } = [];
        public List<FeatureEntity> Features { get; } = [];
        public List<MatchEntity> Matches { get; } = [];

        public GameEntity(string name, string description, List<CardEntity> cards, List<FeatureEntity> features, List<MatchEntity> matches) : this(name, description)
        {
            Cards = cards;
            Features = features;
            Matches = matches;
        }
    }
}
