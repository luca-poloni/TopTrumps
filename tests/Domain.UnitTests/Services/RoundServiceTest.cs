using Domain.Entities;
using Domain.Exceptions;
using Domain.Services;
using FluentAssertions;
using Moq;

namespace Domain.UnitTests.Services
{
    public class RoundServiceTest
    {
        [Fact]
        public void WinnerCard_Should_CardPlayer()
        {
            #region Arrange
            var cardPlayersMock = new List<CardPlayerEntity>
            {
                new(
                    card: new CardEntity(
                        gameId: It.IsAny<uint>(),
                        name: It.IsAny<string>(),
                        image: It.IsAny<byte[]>(),
                        isTopTrumps: It.IsAny<bool>(),
                        game: It.IsAny<GameEntity>(),
                        cardPlayers: It.IsAny<List<CardPlayerEntity>>(),
                        features: [new FeatureEntity(cardId: It.IsAny<uint>(), name: "FeatureByName One", value: 10)]),
                    player: new PlayerEntity(
                        matchId: It.IsAny<uint>(),
                        name: It.IsAny<string>()))
            };

            var roundMock = new RoundService(cardPlayersMock);
            #endregion

            #region Action
            var winnerCard =  roundMock.WinnerCard("FeatureByName One");
            #endregion

            #region Assert
            winnerCard.Should().BeOfType<CardPlayerEntity>();
            #endregion
        }

        [Fact]
        public void WinnerCard_Should_ThrowHasNoWinnerCardException()
        {
            #region Arrange
            var cardPlayersMock = new List<CardPlayerEntity>
            {
                new(
                    card: new CardEntity(
                        gameId: It.IsAny<uint>(),
                        name: It.IsAny<string>(),
                        image: It.IsAny<byte[]>(),
                        isTopTrumps: It.IsAny<bool>(),
                        game: It.IsAny<GameEntity>(),
                        cardPlayers: It.IsAny<List<CardPlayerEntity>>(),
                        features: [new FeatureEntity(cardId: It.IsAny<uint>(), name: "FeatureByName One", value: 10)]),
                    player: new PlayerEntity(
                        matchId: It.IsAny<uint>(),
                        name: It.IsAny<string>()))
            };

            var roundMock = new RoundService(cardPlayersMock);
            #endregion

            #region Action
            var action = () => { roundMock.WinnerCard("FeatureByName Two"); };
            #endregion

            #region Assert
            action.Should().Throw<HasNoWinnerCardException>();
            #endregion
        }

        [Fact]
        public void WinnerCard_Should_ThrowHasMoreThanOneWinnerCardException()
        {
            #region Arrange
            var cardPlayersMock = new List<CardPlayerEntity>
            {
                new(
                    card: new CardEntity(
                        gameId: It.IsAny<uint>(),
                        name: It.IsAny<string>(),
                        image: It.IsAny<byte[]>(),
                        isTopTrumps: It.IsAny<bool>(),
                        game: It.IsAny<GameEntity>(),
                        cardPlayers: It.IsAny<List<CardPlayerEntity>>(),
                        features: [new FeatureEntity(cardId: It.IsAny<uint>(), name: "FeatureByName One", value: 10)]),
                    player: new PlayerEntity(
                        matchId: It.IsAny<uint>(),
                        name: It.IsAny<string>())),
                new(
                    card: new CardEntity(
                        gameId: It.IsAny<uint>(),
                        name: It.IsAny<string>(),
                        image: It.IsAny<byte[]>(),
                        isTopTrumps: It.IsAny<bool>(),
                        game: It.IsAny<GameEntity>(),
                        cardPlayers: It.IsAny<List<CardPlayerEntity>>(),
                        features: [new FeatureEntity(cardId: It.IsAny<uint>(), name: "FeatureByName One", value: 10)]),
                    player: new PlayerEntity(
                        matchId: It.IsAny<uint>(),
                        name: It.IsAny<string>()))
            };

            var roundMock = new RoundService(cardPlayersMock);
            #endregion

            #region Action
            var action = () => { roundMock.WinnerCard("FeatureByName One"); };
            #endregion

            #region Assert
            action.Should().Throw<HasMoreThanOneWinnerCardException>();
            #endregion
        }
    }
}
