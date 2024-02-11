using Domain.Card;
using Domain.CardDeck;
using Domain.Game;
using Domain.Power;
using FluentAssertions;
using Moq;

namespace Domain.UnitTests.Card
{
    public class CardEntityTest
    {
        [Fact]
        public void WinnerPowerByValue_Should_ValidPower()
        {
            #region Arrange
            var card = new CardEntity(
                gameId: It.IsAny<uint>(), 
                name: It.IsAny<string>(), 
                image: It.IsAny<byte[]>(), 
                isTopTrumps: It.IsAny<bool>(), 
                game: It.IsAny<GameEntity>(), 
                cardDecks: It.IsAny<List<CardDeckEntity>>(), 
                powers: [new(cardId: It.IsAny<uint>(), featureId: It.IsAny<uint>(), value: 100)]);
            #endregion

            #region Action
            var winnerPowerByValue = card.WinnerPowerByValue(100);
            #endregion

            #region Assert
            winnerPowerByValue.Should().BeOfType<PowerEntity>();
            #endregion
        }

        [Fact]
        public void WinnerPowerByValue_Should_NoPower()
        {
            #region Arrange
            var card = new CardEntity(
                gameId: It.IsAny<uint>(),
                name: It.IsAny<string>(),
                image: It.IsAny<byte[]>(),
                isTopTrumps: It.IsAny<bool>(),
                game: It.IsAny<GameEntity>(),
                cardDecks: It.IsAny<List<CardDeckEntity>>(),
                powers: [new(cardId: It.IsAny<uint>(), featureId: It.IsAny<uint>(), value: 100)]);
            #endregion

            #region Action
            var winnerPowerByValue = card.WinnerPowerByValue(50);
            #endregion

            #region Assert
            winnerPowerByValue.Should().BeNull();
            #endregion
        }
    }
}
