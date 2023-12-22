using Domain.Entities;
using FluentAssertions;
using Moq;

namespace Domain.UnitTests.Tests.Entities
{
    public class CardEntityTest
    {
        [Fact]
        public void FeatureByName_Should_Feature()
        {
            #region Arrange
            var cardMock = new CardEntity(
                gameId: It.IsAny<uint>(),
                name: It.IsAny<string>(),
                image: It.IsAny<byte[]>(),
                isTopTrumps: It.IsAny<bool>(),
                game: It.IsAny<GameEntity>(),
                cardPlayers: It.IsAny<List<CardPlayerEntity>>(),
                features: [new(It.IsAny<uint>(), "Feature One", It.IsAny<sbyte>())]);
            #endregion

            #region Action
            var feature = cardMock.FeatureByName("Feature One");
            #endregion

            #region Assert
            feature.Should().BeOfType<FeatureEntity>();
            #endregion
        }

        [Fact]
        public void WinnerFeatureByValue_Should_Feature()
        {
            #region Arrange
            var cardMock = new CardEntity(
                gameId: It.IsAny<uint>(),
                name: It.IsAny<string>(),
                image: It.IsAny<byte[]>(),
                isTopTrumps: It.IsAny<bool>(),
                game: It.IsAny<GameEntity>(),
                cardPlayers: It.IsAny<List<CardPlayerEntity>>(),
                features: [new(It.IsAny<uint>(), It.IsAny<string>(), 10)]);
            #endregion

            #region Action
            var feature = cardMock.WinnerFeatureByValue(10);
            #endregion

            #region Assert
            feature.Should().BeOfType<FeatureEntity>();
            #endregion
        }
    }
}