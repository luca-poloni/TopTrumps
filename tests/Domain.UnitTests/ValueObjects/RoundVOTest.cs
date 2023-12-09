using Domain.Entities;
using Domain.Exceptions;
using Domain.ValueObjects;
using FluentAssertions;
using Moq;

namespace Domain.UnitTests.ValueObjects
{
    public class RoundVOTest
    {
        [Fact]
        public void WinnerCard_Should_NotThrowException()
        {
            #region Arrange
            var featureName = "Feature One";
            var cardPlayers = new List<CardPlayerEntity>
            {
                Mock.Of<CardPlayerEntity>(x=> x.Card.Features == new List<FeatureEntity> 
                { 
                    Mock.Of<FeatureEntity>(x=> x.Name == featureName && x.Value == 10) 
                })
            };
            var roundMock = new RoundVO(cardPlayers);
            #endregion

            #region Action
            var action = () => { roundMock.WinnerCard(featureName); };
            #endregion

            #region Assert
            action.Should().NotThrow<HasNoWinnerCardException>();
            #endregion
        }

        [Fact]
        public void WinnerCard_Should_ThrowException()
        {
            #region Arrange
            var cardPlayers = new List<CardPlayerEntity>
            {
                Mock.Of<CardPlayerEntity>(x=> x.Card.Features == new List<FeatureEntity>
                {
                    Mock.Of<FeatureEntity>(x=> x.Name == "Feature One" && x.Value == 10)
                })
            };
            var roundMock = new RoundVO(cardPlayers);
            #endregion

            #region Action
            var action = () => { roundMock.WinnerCard("Feature Two"); };
            #endregion

            #region Assert
            action.Should().Throw<HasNoWinnerCardException>();
            #endregion
        }
    }
}
