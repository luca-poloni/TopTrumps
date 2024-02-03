using Domain.Card;
using Domain.Feature;
using Domain.Game;
using Domain.Match;
using FluentAssertions;
using Moq;

namespace Domain.UnitTests.Game
{
    public class GameEntityTest
    {
        [Fact]
        public void ShuffledCards_Should_ScrambledCards()
        {
            #region Arrange
            var gameMock = new GameEntity(
                name: It.IsAny<string>(),
                description: It.IsAny<string>(),
                cards: [new(gameId: It.IsAny<uint>(), name: It.IsAny<string>(), image: It.IsAny<byte[]>(), isTopTrumps: It.IsAny<bool>())],
                features: It.IsAny<List<FeatureEntity>>(),
                matches: It.IsAny<List<MatchEntity>>());
            #endregion

            #region Action
            var shuffledCards = gameMock.ShuffledCards();
            #endregion

            #region Assert
            shuffledCards.Should().BeOfType<List<CardEntity>>();
            #endregion
        }
    }
}
