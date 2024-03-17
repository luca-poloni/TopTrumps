using Domain.Card;
using Domain.Feature;
using Domain.Power;
using FluentAssertions;

namespace Domain.UnitTests.Feature
{
    public class FeatureEntityTest
    {
        [Fact]
        public void PowerByCard_Should_Be_Power()
        {
            #region Arrange
            var cardMock = new CardEntity();
            var powerMock = new PowerEntity() { Card = cardMock };
            var featureMock = new FeatureEntity() { Powers = [powerMock] };
            #endregion

            #region Action
            var power = featureMock.PowerByCard(cardMock);
            #endregion

            #region Assert
            power.Should().Be(powerMock);
            #endregion
        }

        [Fact]
        public void PowerByCard_Should_ThrowExactly_PowerByCardNotFoundException()
        {
            #region Arrange
            var featureMock = new FeatureEntity();
            var cardMock = new CardEntity();
            #endregion

            #region Action
            var action = () => featureMock.PowerByCard(cardMock);
            #endregion

            #region Assert
            action.Should().ThrowExactly<PowerByCardNotFoundException>();
            #endregion
        }
    }
}
