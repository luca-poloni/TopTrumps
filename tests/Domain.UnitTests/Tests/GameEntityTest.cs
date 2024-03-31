using Domain.Core.Card;
using Domain.Core.Game;
using FluentAssertions;

namespace Domain.UnitTests.Tests
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
