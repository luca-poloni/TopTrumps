using Domain.Game;
using Domain.Game.Entities;
using FluentAssertions;

namespace Domain.UnitTests.Core.Aggregates
{
    public class GameAggregateTest
    {
        [Test]
        public void ShuffledCards_Should_Be_ShuffledCards()
        {
            #region Arrange
            var cardMock = new CardEntity();
            var gameMock = new GameAggregate() { Cards = [cardMock] };

            #endregion

            #region Action
            var shuffledCards = gameMock.ShuffledCards();
            #endregion

            #region Assert
            shuffledCards.Should().Contain(cardMock);
            #endregion
        }

        [Test]
        public void Update_Should_Updated()
        {
            #region Arrange
            var gameMock = new GameAggregate() 
            { 
                Name = "Name", 
                Description = "Description"
            };
            #endregion

            #region Action
            gameMock.Update("Name Update", "Description Update");
            #endregion

            #region Assert
            gameMock.Name.Should().Be("Name Update");
            gameMock.Description.Should().Be("Description Update");
            #endregion
        }

        [Test]
        public void AddCard_Should_AddedCard()
        {
            #region Arrange
            var gameMock = new GameAggregate();
            #endregion

            #region Action
            gameMock.AddCard("Card Name", true);
            #endregion

            #region Assert
            gameMock.Cards.Should().HaveCount(1);
            #endregion
        }

        [Test]
        public void AddFeature_Should_AddedFeature()
        {
            #region Arrange
            var gameMock = new GameAggregate();
            #endregion

            #region Action
            gameMock.AddFeature("Feature Name");
            #endregion

            #region Assert
            gameMock.Features.Should().HaveCount(1);
            #endregion
        }
    }
}
