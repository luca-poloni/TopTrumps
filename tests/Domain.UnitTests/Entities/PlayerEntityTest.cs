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
            var playerMock = new Mock<PlayerEntity>();
            var cardMock = Mock.Of<CardEntity>(x => x.Name == "Card One");
            var cardPlayerMock = Mock.Of<CardPlayerEntity>(x => x.Card == cardMock && x.Player == playerMock.Object);
            var cardPlayersMock = new List<CardPlayerEntity> { cardPlayerMock };
            playerMock.Setup(x => x.CardPlayers).Returns(cardPlayersMock);
            #endregion

            #region Action
            var action = () => { playerMock.Object.GiveCard("Card One"); };
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
            var cardMock = Mock.Of<CardEntity>(x => x.Name == "Card One");
            var cardPlayerMock = Mock.Of<CardPlayerEntity>(x => x.Card == cardMock && x.Player == playerMock.Object);
            var cardPlayersMock = new List<CardPlayerEntity> { cardPlayerMock };
            playerMock.Setup(x => x.CardPlayers).Returns(cardPlayersMock);
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
