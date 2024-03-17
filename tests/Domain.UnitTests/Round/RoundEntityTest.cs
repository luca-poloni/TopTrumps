using Domain.Feature;
using Domain.Match;
using Domain.Player;
using Domain.Power;
using Domain.Round;
using FluentAssertions;

namespace Domain.UnitTests.Round
{
    public class RoundEntityTest
    {
        [Fact]
        public void TakeCards_Should_NotThrow()
        {
            #region Arrange
            var roundMock = new RoundEntity();
            var playerCardsMock = new List<PlayerEntity.PlayerCardEntity>() { new() };
            #endregion

            #region Action
            var action = () => roundMock.TakeCards(playerCardsMock);
            #endregion

            #region Assert
            action.Should().NotThrow();
            #endregion
        }

        [Fact]
        public void WinnerPlayerByFeature_Should_NotBeNull()
        {
            #region Arrange
            var featureMock = new FeatureEntity();
            var powerMock = new PowerEntity() { Feature = featureMock };
            var playerMock = new PlayerEntity();
            var roundMock = new RoundEntity() 
            { 
                RoundCards = [new RoundEntity.RoundCardEntity() 
                { 
                    PlayerCard = new PlayerEntity.PlayerCardEntity 
                    { 
                        MatchCard = new MatchEntity.MatchCardEntity 
                        { 
                            Card = new Domain.Card.CardEntity 
                            { 
                                Powers = [powerMock] 
                            } 
                        },
                        Player = playerMock
                    } 
                }] 
            };
            #endregion

            #region Action
            var winnerPlayer = roundMock.WinnerPlayerByFeature(featureMock);
            #endregion

            #region Assert
            winnerPlayer.Should().NotBeNull();
            #endregion
        }

        [Fact]
        public void WinnerPlayerByFeature_Should_ThrowExactly_HasNoWinnerRoundCardException()
        {
            #region Arrange
            var roundMock = new RoundEntity();
            var featureMock = new FeatureEntity();
            #endregion

            #region Action
            var action = () => roundMock.WinnerPlayerByFeature(featureMock);
            #endregion

            #region Assert
            action.Should().ThrowExactly<HasNoWinnerRoundCardException>();
            #endregion
        }

        [Fact]
        public void GiveCardsToWinnerPlayer_Should_NotThrow()
        {
            #region Arrange
            var roundMock = new RoundEntity() { RoundCards = [new RoundEntity.RoundCardEntity() { PlayerCard = new ()}] };
            var playerMock = new PlayerEntity();
            #endregion

            #region Action
            var action = () => roundMock.GiveCardsToWinnerPlayer(playerMock);
            #endregion

            #region Assert
            action.Should().NotThrow();
            #endregion
        }
    }
}
