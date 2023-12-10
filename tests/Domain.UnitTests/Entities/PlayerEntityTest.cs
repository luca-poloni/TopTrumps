using Domain.Entities;
using Domain.Exceptions;
using FluentAssertions;

namespace Domain.UnitTests.Entities
{
    public class PlayerEntityTest
    {
        [Fact]
        public void IsAvailable_Should_True()
        {
            #region Arrange
            var playerMock = new PlayerEntity();
            var cardMock = new CardEntity();
            var cardPlayerMock = new CardPlayerEntity { Card = cardMock, Player = playerMock };
            var cardPlayersMock = new List<CardPlayerEntity> { cardPlayerMock };
            playerMock.CardPlayers = cardPlayersMock;
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
        public void GiveCard_Should_CardPlayer()
        {
            #region Arrange
            var playerMock = new PlayerEntity();
            var cardMock = new CardEntity() { Name = "Card One" };
            var cardPlayerMock = new CardPlayerEntity { Card = cardMock, Player = playerMock };
            var cardPlayersMock = new List<CardPlayerEntity> { cardPlayerMock };
            playerMock.CardPlayers = cardPlayersMock;
            #endregion

            #region Action
            var cardPlayer = playerMock.GiveCard("Card One");
            #endregion

            #region Assert
            cardPlayer.Should().BeOfType<CardPlayerEntity>();
            #endregion
        }

        [Fact]
        public void GiveCard_Should_ThrowCardNotFoundException()
        {
            #region Arrange
            var playerMock = new PlayerEntity();
            var cardMock = new CardEntity() { Name = "Card One" };
            var cardPlayerMock = new CardPlayerEntity { Card = cardMock, Player = playerMock };
            var cardPlayersMock = new List<CardPlayerEntity> { cardPlayerMock };
            playerMock.CardPlayers = cardPlayersMock;
            #endregion

            #region Action
            var action = () => { playerMock.GiveCard("Card Two"); };
            #endregion

            #region Assert
            action.Should().Throw<CardNotFoundException>();
            #endregion
        }

        [Fact]
        public void TakeCards_Should_NotThrowCardNotFoundException()
        {
            #region Arrange
            var playerMock = new PlayerEntity();
            var cardMock = new CardEntity();
            var cardPlayerMock = new CardPlayerEntity { Card = cardMock, Player = playerMock };
            var cardPlayersMock = new List<CardPlayerEntity> { cardPlayerMock };
            playerMock.CardPlayers = cardPlayersMock;
            #endregion

            #region Action
            var action = () => { playerMock.TakeCards(cardPlayersMock); };
            #endregion

            #region Assert
            action.Should().NotThrow<CardNotFoundException>();
            #endregion
        }
    }
}
