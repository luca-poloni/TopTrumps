using Domain.Entities;
using Domain.Exceptions;
using FluentAssertions;
using Moq;

namespace Domain.UnitTests.Entities
{
    public class PlayerEntityTest
    {
        [Fact]
        public void IsAvailable_Should_True()
        {
            #region Arrange
            var playerMock = new PlayerEntity(
                 matchId: It.IsAny<uint>(),
                 name: It.IsAny<string>(),
                 match: It.IsAny<MatchEntity>(),
                 cardPlayers: [new(
                     card: new CardEntity(
                         gameId: It.IsAny<uint>(),
                         name: It.IsAny<string>(),
                         image: It.IsAny<byte[]>(),
                         isTopTrumps: It.IsAny<bool>(),
                         game: It.IsAny<GameEntity>(),
                         cardPlayers: It.IsAny<List<CardPlayerEntity>>(),
                         features: It.IsAny<List<FeatureEntity>>()),
                     player: new PlayerEntity(
                         matchId: It.IsAny<uint>(),
                         name: It.IsAny<string>()))]);

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
            var playerMock = new PlayerEntity(
                matchId: It.IsAny<uint>(),
                name: It.IsAny<string>(),
                match: It.IsAny<MatchEntity>(),
                cardPlayers: []);
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
            var playerMock = new PlayerEntity(
                matchId: It.IsAny<uint>(),
                name: It.IsAny<string>(),
                match: It.IsAny<MatchEntity>(),
                cardPlayers: [new CardPlayerEntity(
                    card: new CardEntity(
                        gameId: It.IsAny<uint>(),
                        name: It.IsAny<string>(),
                        image: It.IsAny<byte[]>(),
                        isTopTrumps: It.IsAny<bool>(),
                        game: It.IsAny<GameEntity>(),
                        cardPlayers: It.IsAny<List<CardPlayerEntity>>(),
                        features: [new(cardId: It.IsAny<uint>(), name: It.IsAny<string>(), value: It.IsAny<uint>())]),
                    player: new PlayerEntity(
                        matchId: It.IsAny<uint>(),
                        name: It.IsAny<string>()))]);
            #endregion

            #region Action
            var cardPlayer = playerMock.GiveCard(0);
            #endregion

            #region Assert
            cardPlayer.Should().BeOfType<CardPlayerEntity>();
            #endregion
        }

        [Fact]
        public void TakeCards_Should_NotThrowCardNotFoundException()
        {
            #region Arrange
            var playerMock = new PlayerEntity(
                matchId: It.IsAny<uint>(),
                name: It.IsAny<string>(),
                match: It.IsAny<MatchEntity>(),
                cardPlayers: It.IsAny<List<CardPlayerEntity>>());

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
                        features: It.IsAny<List<FeatureEntity>>()),
                    player: new PlayerEntity(
                        matchId: It.IsAny<uint>(),
                        name: It.IsAny<string>()))
            };
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
