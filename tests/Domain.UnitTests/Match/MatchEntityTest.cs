using Domain.Game;
using Domain.Match;
using Domain.Player;
using Domain.Round;
using FluentAssertions;
using Moq;

namespace Domain.UnitTests.Match
{
    public class MatchEntityTest
    {
        [Fact]
        public void Start_Should_NotThrowMatchIsFinishException()
        {
            #region Arrange
            var match = new MatchEntity(gameId: It.IsAny<uint>());
            #endregion

            #region Action
            var action = match.Start;
            #endregion

            #region Assert
            action.Should().NotThrow<MatchIsFinishException>();
            #endregion
        }

        [Fact]
        public void Start_Should_ThrowMatchIsFinishException()
        {
            #region Arrange
            var match = new MatchEntity(
                gameId: It.IsAny<uint>(), 
                isFinish: true, 
                game: It.IsAny<GameEntity>(), 
                players: It.IsAny<List<PlayerEntity>>(), 
                rounds: It.IsAny<List<RoundEntity>>());
            #endregion

            #region Action
            var action = match.Start;
            #endregion

            #region Assert
            action.Should().Throw<MatchIsFinishException>();
            #endregion
        }

        [Fact]
        public void VerifyMatchIsFinish_Should_NotThrowException()
        {
            #region Arrange
            var match = new MatchEntity(
                gameId: It.IsAny<uint>(),
                isFinish: true,
                game: It.IsAny<GameEntity>(),
                players: [new(matchId: It.IsAny<uint>(), name: It.IsAny<string>())],
                rounds: It.IsAny<List<RoundEntity>>());
            #endregion

            #region Action
            var action = match.VerifyMatchIsFinish;
            #endregion

            #region Assert
            action.Should().NotThrow();
            #endregion
        }
    }
}
