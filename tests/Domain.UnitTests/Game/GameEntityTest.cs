using Domain.Card;
using Domain.Game;
using FluentAssertions;

namespace Domain.UnitTests.Game
{
    public class GameEntityTest
    {
        [Fact]
        public void ShuffledCards_Should_NotThrow()
        {
            #region Arrange
            var cardMock = new CardEntity();
            var gameMock = new GameEntity() { Cards = [cardMock] };

            #endregion

            #region Action
            var action = gameMock.ShuffledCards;
            #endregion

            #region Assert
            action.Should().NotThrow();
            #endregion
        }
    }
}
