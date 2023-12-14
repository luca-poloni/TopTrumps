using Domain.Entities;
using Domain.Exceptions;
using FluentAssertions;

namespace Domain.UnitTests.Entities
{
    public class MatchEntityTest
    {
        [Fact]
        public void Play_Should_NotThrowException()
        {
            #region Arrange
            var gameMock = new GameEntity
            {
                Cards =
                [
                    new CardEntity()
                ]
            };
            var playersMock = new List<PlayerEntity>
            {
                new()
            };
            var matchMock = new MatchEntity { Game = gameMock, Players = playersMock };
            #endregion

            #region Action
            var action = matchMock.Play;
            #endregion

            #region Assert
            action.Should().NotThrow();
            #endregion
        }

        [Fact]
        public void Move_Should_NotThrowException()
        {
            #region Arrange
            var gameMock = new GameEntity
            {
                Cards =
                [
                    new CardEntity()
                ]
            };

            var playersMock = new List<PlayerEntity>
            {
                new() 
                { 
                    CardPlayers  =
                    [
                        new CardPlayerEntity 
                        { 
                            Card = new CardEntity 
                            { 
                                Features =
                                [
                                    new FeatureEntity { Name = "Feature One", Value = 10 } 
                                ] 
                            } 
                        } 
                    ] 
                },
                new()
                {
                    CardPlayers  =
                    [
                        new CardPlayerEntity
                        {
                            Card = new CardEntity
                            {
                                Features =
                                [
                                    new FeatureEntity { Name = "Feature One", Value = 5 }
                                ]
                            }
                        }
                    ]
                }
            };

            foreach (var playerMock in playersMock)
                foreach (var cardPlayerMock in playerMock.CardPlayers)
                    cardPlayerMock.Player = playerMock;

            var matchMock = new MatchEntity { Game = gameMock, Players = playersMock };
            #endregion

            #region Action
            var action = () => { matchMock.Move("Feature One"); };
            #endregion

            #region Assert
            action.Should().NotThrow();
            #endregion
        }

        [Fact]
        public void Move_Should_ThrowMatchIsFinishException()
        {
            #region Arrange
            var matchMock = new MatchEntity { IsFinish = true };
            #endregion

            #region Action
            var action = () => { matchMock.Move(string.Empty); };
            #endregion

            #region Assert
            action.Should().Throw<MatchIsFinishException>();
            #endregion
        }
    }
}
