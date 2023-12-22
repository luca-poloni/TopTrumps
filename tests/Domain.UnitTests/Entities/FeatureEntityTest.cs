using Domain.Entities;
using FluentAssertions;
using Moq;

namespace Domain.UnitTests.Entities
{
    public class FeatureEntityTest
    {
        [Fact]
        public void IsHigher_Should_True()
        {
            #region Arrange
            var featureMock = new FeatureEntity(
                cardId: It.IsAny<uint>(), 
                name: It.IsAny<string>(), 
                value: 10);

            var anotherFeatureMock = new FeatureEntity(
                cardId: It.IsAny<uint>(),
                name: It.IsAny<string>(),
                value: 5);
            #endregion

            #region Action
            var isHigher = featureMock.IsHigher(anotherFeatureMock);
            #endregion

            #region Assert
            isHigher.Should().BeTrue();
            #endregion
        }

        [Fact]
        public void IsHigher_Should_False()
        {
            #region Arrange
            var featureMock = new FeatureEntity(
                cardId: It.IsAny<uint>(),
                name: It.IsAny<string>(),
                value: 5);

            var anotherFeatureMock = new FeatureEntity(
                cardId: It.IsAny<uint>(),
                name: It.IsAny<string>(),
                value: 10);
            #endregion

            #region Action
            var isHigher = featureMock.IsHigher(anotherFeatureMock);
            #endregion

            #region Assert
            isHigher.Should().BeFalse();
            #endregion
        }
    }
}
