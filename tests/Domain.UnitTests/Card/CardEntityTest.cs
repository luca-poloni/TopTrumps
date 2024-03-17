using Domain.Card;
using Domain.Feature;
using Domain.Power;
using FluentAssertions;

namespace Domain.UnitTests.Card
{
    public class CardEntityTest
    {
        [Fact]
        public void PowerValueByFeature_Should_Be_PowerValue()
        {
            #region Arrange
            var featureMock = new FeatureEntity();
            var powerMock = new PowerEntity() { Feature = featureMock };
            var cardMock = new CardEntity() { Powers = [powerMock] };
            #endregion

            #region Action
            var powerValue = cardMock.PowerValueByFeature(featureMock);
            #endregion

            #region Assert
            powerValue.Should().Be(powerMock.Value);
            #endregion
        }

        [Fact]
        public void PowerValueByFeature_Should_Be_Null()
        {
            #region Arrange
            var featureMock = new FeatureEntity();
            var cardMock = new CardEntity();
            #endregion

            #region Action
            var powerValue = cardMock.PowerValueByFeature(featureMock);
            #endregion

            #region Assert
            powerValue.Should().BeNull();
            #endregion
        }
    }
}
