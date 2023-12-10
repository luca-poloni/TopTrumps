using Domain.Entities;
using FluentAssertions;

namespace Domain.UnitTests.Entities
{
    public class GameEntityTest
    {
        [Fact]
        public void ShuffledCards_Should_CardList()
        {
            #region Arrange
            var gameMock = new GameEntity 
            { 
                Cards =
                [
                    new CardEntity() 
                ] 
            };
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
