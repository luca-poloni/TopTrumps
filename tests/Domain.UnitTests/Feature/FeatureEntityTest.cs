using Domain.Card;
using Domain.Feature;
using Domain.Game;
using Domain.Power;
using FluentAssertions;
using Moq;

namespace Domain.UnitTests.Feature
{
    public class FeatureEntityTest
    {
        [Fact]
        public void PowerByCard_Should_ValidPower()
        {
            #region Arrange
            var card = new CardEntity(
                gameId: It.IsAny<uint>(), 
                name: It.IsAny<string>(), 
                image: It.IsAny<byte[]>(), 
                isTopTrumps: It.IsAny<bool>());

            var feature = new FeatureEntity(
                gameId: It.IsAny<uint>(),
                name: It.IsAny<string>(),
                game: It.IsAny<GameEntity>(),
                powers: [new(
                    cardId: It.IsAny<uint>(), 
                    featureId: It.IsAny<uint>(), 
                    value: It.IsAny<uint>(), 
                    card: card, 
                    feature: It.IsAny<FeatureEntity>())]);
            #endregion

            #region Action
            var winnerPowerByValue = feature.PowerByCard(card);
            #endregion

            #region Assert
            winnerPowerByValue.Should().BeOfType<PowerEntity>();
            #endregion
        }

        [Fact]
        public void PowerByCard_Should_NoPower()
        {
            #region Arrange
            var card = new CardEntity(
                gameId: It.IsAny<uint>(),
                name: It.IsAny<string>(),
                image: It.IsAny<byte[]>(),
                isTopTrumps: It.IsAny<bool>());

            var feature = new FeatureEntity(
                gameId: It.IsAny<uint>(),
                name: It.IsAny<string>(),
                game: It.IsAny<GameEntity>(),
                powers: [new(
                    cardId: It.IsAny<uint>(),
                    featureId: It.IsAny<uint>(),
                    value: It.IsAny<uint>(),
                    card: It.IsAny<CardEntity>(),
                    feature: It.IsAny<FeatureEntity>())]);
            #endregion

            #region Action
            var winnerPowerByValue = feature.PowerByCard(card);
            #endregion

            #region Assert
            winnerPowerByValue.Should().BeNull();
            #endregion
        }
    }
}
