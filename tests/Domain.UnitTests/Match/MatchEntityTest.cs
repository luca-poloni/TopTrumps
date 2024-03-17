using Domain.Game;
using Domain.Match;
using Domain.Player;
using FluentAssertions;

namespace Domain.UnitTests.Match
{
    public class MatchEntityTest
    {
        [Fact]
        public void TakeShuffledCards_Should_NotThrow()
        {
            #region Arrange
            var matchMock = new MatchEntity()
            {
                Game = new GameEntity()
                {
                    Cards = [new()]
                }
            };
            #endregion

            #region Action
            var action = matchMock.TakeShuffledCards;
            #endregion

            #region Assert
            action.Should().NotThrow();
            #endregion
        }

        [Fact]
        public void GiveMatchCards_Should_NotThrow()
        {
            #region Arrange
            var matchMock = new MatchEntity()
            {
                Players = [new()],
                MatchCards = [new()]
            };
            #endregion

            #region Action
            var action = matchMock.GiveMatchCards;
            #endregion

            #region Assert
            action.Should().NotThrow();
            #endregion
        }

        [Fact]
        public void GiveMatchCards_Should_ThrowExactly_HasNoMoreCardsToGiveException()
        {
            #region Arrange
            var matchMock = new MatchEntity() { Players = [new()] };
            #endregion

            #region Action
            var action = matchMock.GiveMatchCards;
            #endregion

            #region Assert
            action.Should().ThrowExactly<HasNoMoreCardsToGiveException>();
            #endregion
        }

        [Fact]
        public void WinnerPlayerByCard_Should_NotBeNull()
        {
            #region Arrange
            var matchCardMock = new MatchEntity.MatchCardEntity();
            var playerMock = new PlayerEntity() { PlayerCards = [new() { MatchCard = matchCardMock }] };
            var matchMock = new MatchEntity() { Players = [playerMock] };
            #endregion

            #region Action
            var winnerPlayer = matchMock.WinnerPlayerByCard(matchCardMock);
            #endregion

            #region Assert
            winnerPlayer.Should().NotBeNull();
            #endregion
        }

        [Fact]
        public void WinnerPlayerByCard_Should_ThrowExactly_HasNoWinnerPlayerException()
        {
            #region Arrange
            var matchCardMock = new MatchEntity.MatchCardEntity();
            var matchMock = new MatchEntity() { Players = [new()] };
            #endregion

            #region Action
            var action = () => matchMock.WinnerPlayerByCard(matchCardMock);
            #endregion

            #region Assert
            action.Should().ThrowExactly<HasNoWinnerPlayerException>();
            #endregion
        }

        [Fact]
        public void VerifyMatchIsFinish_Should_NotThrow()
        {
            #region Arrange
            var matchMock = new MatchEntity() { Players = [new PlayerEntity() { PlayerCards = [new() { MatchCard = new() }] }] };
            #endregion

            #region Action
            var action = matchMock.VerifyMatchIsFinish;
            #endregion

            #region Assert
            action.Should().NotThrow();
            #endregion
        }
    }
}
