using Ardalis.SharedKernel;
using Domain.Common.Primitives;
using Domain.Game.Entities;
using Domain.Game.Exceptions;

namespace Domain.Game
{
    public class GameAggregate : BaseAuditableEntity, IAggregateRoot
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
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

        public FeatureEntity AddFeature(string name)
        {
            var feature = new FeatureEntity
            {
                GameId = Id,
                Name = name
            };

            Features.Add(feature);

            return feature;
        }

        public FeatureEntity SingleFeature()
        {
            return Features
                .SingleOrDefault() ?? throw new SingleFeatureNotFoundException();
        }

        public void RemoveSingleFeature()
        {
            Features.Remove(SingleFeature());
        }

        public CardEntity AddCard(string name, bool isTopTrumps)
        {
            var card = new CardEntity
            {
                GameId = Id,
                Name = name,
                IsTopTrumps = isTopTrumps
            };

            Cards.Add(card);

            return card;
        }

        public CardEntity SingleCard()
        {
            return Cards
                .SingleOrDefault() ?? throw new SingleCardNotFoundException();
        }

        public void RemoveSingleCard()
        {
            Cards.Remove(SingleCard());
        }
    }
}
