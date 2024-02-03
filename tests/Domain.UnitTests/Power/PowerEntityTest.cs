using Domain.Power;
using FluentAssertions;
using Moq;

namespace Domain.UnitTests.Power
{
    public class PowerEntityTest
    {
        [Fact]
        public void IsHigher_Should_True()
        {
            #region Arrange
            var powerMock = new PowerEntity(
                cardId: It.IsAny<uint>(),
                featureId: It.IsAny<uint>(),
                value: 10);

            var anotherPowerMock = new PowerEntity(
                cardId: It.IsAny<uint>(),
                featureId: It.IsAny<uint>(),
                value: 5);
            #endregion

            #region Action
            var isHigher = powerMock.IsHigher(anotherPowerMock);
            #endregion

            #region Assert
            isHigher.Should().BeTrue();
            #endregion
        }

        [Fact]
        public void IsHigher_Should_False()
        {
            #region Arrange
            var powerMock = new PowerEntity(
                cardId: It.IsAny<uint>(),
                featureId: It.IsAny<uint>(),
                value: 5);

            var anotherPowerMock = new PowerEntity(
                cardId: It.IsAny<uint>(),
                featureId: It.IsAny<uint>(),
                value: 10);
            #endregion

            #region Action
            var isHigher = powerMock.IsHigher(anotherPowerMock);
            #endregion

            #region Assert
            isHigher.Should().BeFalse();
            #endregion
        }
    }
}
