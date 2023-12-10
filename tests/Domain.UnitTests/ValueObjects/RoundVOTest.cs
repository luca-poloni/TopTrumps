using Domain.Entities;
using Domain.Exceptions;
using Domain.ValueObjects;
using FluentAssertions;

namespace Domain.UnitTests.ValueObjects
{
    public class RoundVOTest
    {
        [Fact]
        public void WinnerCard_Should_CardPlayer()
        {
            #region Arrange
            var cardPlayersMock = new List<CardPlayerEntity>
            {
                new() 
                { 
                    Card = new CardEntity 
                    { 
                        Features =
                        [
                            new FeatureEntity { Name = "FeatureByName One", Value = 10 } 
                        ] 
                    } 
                }
            };
            var roundMock = new RoundVO(cardPlayersMock);
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
                new() 
                {
                    Card = new CardEntity
                    {
                        Features =
                        [
                            new FeatureEntity { Name = "FeatureByName One", Value = 10 }
                        ]
                    }
                }
            };
            var roundMock = new RoundVO(cardPlayersMock);
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
                new() 
                {
                    Card = new CardEntity
                    {
                        Features =
                        [
                            new FeatureEntity { Name = "FeatureByName One", Value = 10 }
                        ]
                    }
                },
                new() 
                {
                    Card = new CardEntity
                    {
                        Features =
                        [
                            new FeatureEntity { Name = "FeatureByName One", Value = 10 }
                        ]
                    }
                }
            };
            var roundMock = new RoundVO(cardPlayersMock);
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
