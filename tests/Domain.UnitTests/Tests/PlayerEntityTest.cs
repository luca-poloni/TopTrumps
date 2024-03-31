using Domain.Core.Match;
using Domain.Core.Player;
using FluentAssertions;

namespace Domain.UnitTests.Tests
{
    public class PlayerEntityTest
    {
        [Fact]
        public void IsAvailable_Should_BeTrue()
        {
            #region Arrange
            var playerMock = new PlayerEntity() { PlayerCards = [new PlayerEntity.PlayerCardEntity()] };
            #endregion

            #region Action
            var isAvailable = playerMock.IsAvailable();
            #endregion

            #region Assert
            isAvailable.Should().BeTrue();
            #endregion
        }

        [Fact]
        public void IsAvailable_Should_BeFalse()
        {
            #region Arrange
            var playerMock = new PlayerEntity();
            #endregion

            #region Action
            var isAvailable = playerMock.IsAvailable();
            #endregion

            #region Assert
            isAvailable.Should().BeFalse();
            #endregion
        }

        [Fact]
        public void IsWinnerCardBelongPlayer_Should_BeTrue()
        {
            #region Arrange
            var matchCardMock = new MatchEntity.MatchCardEntity();
            var playerMock = new PlayerEntity() { PlayerCards = [new PlayerEntity.PlayerCardEntity() { MatchCard = matchCardMock }] };
            #endregion

            #region Action
            var isWinnerCardBelongPlayer = playerMock.IsWinnerCardBelongPlayer(matchCardMock);
            #endregion

            #region Assert
            isWinnerCardBelongPlayer.Should().BeTrue();
            #endregion
        }

        [Fact]
        public void IsWinnerCardBelongPlayer_Should_BeFalse()
        {
            #region Arrange
            var matchCardMock = new MatchEntity.MatchCardEntity();
            var playerMock = new PlayerEntity() { PlayerCards = [new PlayerEntity.PlayerCardEntity()] };
            #endregion

            #region Action
            var isWinnerCardBelongPlayer = playerMock.IsWinnerCardBelongPlayer(matchCardMock);
            #endregion

            #region Assert
            isWinnerCardBelongPlayer.Should().BeFalse();
            #endregion
        }

        [Fact]
        public void TakeCards_Should_NotThrow()
        {
            #region Arrange
            var playerMock = new PlayerEntity();
            var matchCardsMock = new List<MatchEntity.MatchCardEntity>() { new() };
            #endregion

            #region Action
            var action = () => playerMock.TakeCards(matchCardsMock);
            #endregion

            #region Assert
            action.Should().NotThrow();
            #endregion
        }

        [Fact]
        public void TakePlayerCards_Should_NotThrow()
        {
            #region Arrange
            var playerMock = new PlayerEntity();
            var playerCardsMock = new List<PlayerEntity.PlayerCardEntity>() { new() };
            #endregion

            #region Action
            var action = () => playerMock.TakePlayerCards(playerCardsMock);
            #endregion

            #region Assert
            action.Should().NotThrow();
            #endregion
        }
    }
}
