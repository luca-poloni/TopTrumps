using Domain.CardDeck;
using Domain.Match;
using Domain.Player;
using FluentAssertions;
using Moq;
using System.Text.RegularExpressions;

namespace Domain.UnitTests.Player
{
    public class PlayerEntityTest
    {
        [Fact]
        public void IsAvailable_Should_True()
        {
            #region Arrange
            var playerMock = new PlayerEntity(
                 matchId: It.IsAny<uint>(),
                 name: It.IsAny<string>(),
                 match: It.IsAny<MatchEntity>(),
                 cardDecks: [new(cardId: It.IsAny<uint>(), playerId: It.IsAny<uint>())]);

            #endregion

            #region Action
            var isAvailable = playerMock.IsAvailable();
            #endregion

            #region Assert
            isAvailable.Should().BeTrue();
            #endregion
        }

        [Fact]
        public void IsAvailable_Should_False()
        {
            #region Arrange
            var playerMock = new PlayerEntity(
                matchId: It.IsAny<uint>(),
                name: It.IsAny<string>(),
                match: It.IsAny<MatchEntity>(),
                cardDecks: []);
            #endregion

            #region Action
            var isAvailable = playerMock.IsAvailable();
            #endregion

            #region Assert
            isAvailable.Should().BeFalse();
            #endregion
        }

        [Fact]
        public void TakeInitialCards_Should_NotThrow()
        {
            #region Arrange
            var playerMock = new PlayerEntity(
                matchId: It.IsAny<uint>(),
                name: It.IsAny<string>(),
                match: It.IsAny<MatchEntity>(),
                cardDecks: []);
            var cardDecksMock = new List<CardDeckEntity> { new(cardId: It.IsAny<uint>(), playerId: It.IsAny<uint>()) };
            #endregion

            #region Action
            var action = () => playerMock.TakeInitialCards(cardDecksMock);
            #endregion

            #region Assert
            action.Should().NotThrow();
            #endregion
        }

        [Fact]
        public void TakeRoundCards_Should_NotThrow()
        {
            #region Arrange
            var playerMock = new PlayerEntity(
                matchId: It.IsAny<uint>(),
                name: It.IsAny<string>(),
                match: It.IsAny<MatchEntity>(),
                cardDecks: []);
            var cardDecksMock = new List<CardDeckEntity> { new(cardId: It.IsAny<uint>(), playerId: It.IsAny<uint>()) };
            #endregion

            #region Action
            var action = () => playerMock.TakeRoundCards(cardDecksMock);
            #endregion

            #region Assert
            action.Should().NotThrow();
            #endregion
        }
    }
}
