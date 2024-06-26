using Ardalis.SharedKernel;
using Domain.Common;
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

        public void RemoveFeature(Guid featureId)
        {
            Features.Remove(FeatureById(featureId));
        }

        public FeatureEntity FeatureById(Guid featureId)
        {
            return Features
                .SingleOrDefault(feature => feature.HasThisId(featureId)) ?? throw new FeatureByIdNotFoundException();
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

        public void RemoveCard(Guid cardId)
        {
            Cards.Remove(CardById(cardId));
        }

        public CardEntity CardById(Guid cardId)
        {
            return Cards
                .SingleOrDefault(card => card.HasThisId(cardId)) ?? throw new FeatureByIdNotFoundException();
        }
    }
}
