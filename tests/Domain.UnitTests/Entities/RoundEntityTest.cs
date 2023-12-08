using Domain.Entities;
using Domain.Exceptions;
using FluentAssertions;
using Moq;

namespace Domain.UnitTests.Entities
{
    public class RoundEntityTest
    {
        [Fact]
        public void WinnerCard_Should_NotThrowException()
        {
            #region Arrange
            var featureName = "Feature One";
            var roundMock = new Mock<RoundEntity>();
            var cardPlayerRounds = new List<CardPlayerRoundEntity> 
            { 
                new() 
                { 
                    CardPlayer = new() 
                    { 
                        Card = new() 
                        { 
                            Features = new List<FeatureEntity> 
                            {
                                new() { Name = featureName, Value = 10 } 
                            } 
                        } 
                    } 
                } 
            };
            roundMock.Setup(x => x.CardPlayerRounds).Returns(cardPlayerRounds);
            #endregion

            #region Action
            var action = () => { roundMock.Object.WinnerCard(featureName); };
            #endregion

            #region Assert
            action.Should().NotThrow<HasNoWinnerCardException>();
            #endregion
        }

        [Fact]
        public void WinnerCard_Should_NotException()
        {
            #region Arrange
            var roundMock = new Mock<RoundEntity>();
            var cardPlayerRounds = new List<CardPlayerRoundEntity>
            {
                new()
                {
                    CardPlayer = new()
                    {
                        Card = new()
                        {
                            Features = new List<FeatureEntity>
                            {
                                new() { Name = "Feature One" }
                            }
                        }
                    }
                }
            };
            roundMock.Setup(x => x.CardPlayerRounds).Returns(cardPlayerRounds);
            #endregion

            #region Action
            var action = () => { roundMock.Object.WinnerCard("Feature Two"); };
            #endregion

            #region Assert
            action.Should().Throw<HasNoWinnerCardException>();
            #endregion
        }
    }
}
