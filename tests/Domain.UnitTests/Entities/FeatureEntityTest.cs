using Domain.Entities;
using FluentAssertions;

namespace Domain.UnitTests.Entities
{
    public class FeatureEntityTest
    {
        [Fact]
        public void IsHigher_Should_True()
        {
            #region Arrange
            var featureMock = new FeatureEntity { Value = 10 };
            var anotherFeatureMock = new FeatureEntity { Value = 5 };
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
            var featureMock = new FeatureEntity { Value = 5 };
            var anotherFeatureMock = new FeatureEntity { Value = 10 };
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
