using Domain.Entities;
using FluentAssertions;

namespace Domain.UnitTests.Entities
{
    public class CardEntityTest
    {
        [Fact]
        public void FeatureByName_Should_Feature()
        {
            #region Arrange
            var cardMock = new CardEntity 
            { 
                Features =
                [
                    new FeatureEntity { Name = "Feature One" } 
                ] 
            };
            #endregion

            #region Action
            var feature = cardMock.FeatureByName("Feature One");
            #endregion

            #region Assert
            feature.Should().BeOfType<FeatureEntity>();
            #endregion
        }

        [Fact]
        public void WinnerFeatureByValue_Should_Feature()
        {
            #region Arrange
            var cardMock = new CardEntity
            {
                Features =
                [
                    new FeatureEntity { Value = 10 }
                ]
            };
            #endregion

            #region Action
            var feature = cardMock.WinnerFeatureByValue(10);
            #endregion

            #region Assert
            feature.Should().BeOfType<FeatureEntity>();
            #endregion
        }
    }
}
