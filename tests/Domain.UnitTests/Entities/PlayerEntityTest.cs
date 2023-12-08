using Domain.Entities;
using Domain.Exceptions;
using FluentAssertions;
using Moq;

namespace Domain.UnitTests.Entities
{
    public class PlayerEntityTest
    {
        [Fact]
        public void GiveCard_Should_NotThrowException()
        {
            #region Arrange
            var cardName = "Card One";
            var playerMock = new Mock<PlayerEntity>();
            var cardPlayers = new List<CardPlayerEntity> { new() { Card = new() { Name = cardName } } };
            playerMock.Setup(x => x.CardPlayers).Returns(cardPlayers);
            #endregion

            #region Action
            var action = () => { playerMock.Object.GiveCard(cardName); };
            #endregion

            #region Assert
            action.Should().NotThrow<CardNotFoundException>(); 
            #endregion
        }

        [Fact]
        public void GiveCard_Should_ThrowException()
        {
            #region Arrange
            var playerMock = new Mock<PlayerEntity>();
            var cardPlayers = new List<CardPlayerEntity> { new() { Card = new() { Name = "Card One" } } };
            playerMock.Setup(x => x.CardPlayers).Returns(cardPlayers);
            #endregion

            #region Action
            var action = () => { playerMock.Object.GiveCard("Card Two"); };
            #endregion

            #region Assert
            action.Should().Throw<CardNotFoundException>();
            #endregion
        }
    }
}
