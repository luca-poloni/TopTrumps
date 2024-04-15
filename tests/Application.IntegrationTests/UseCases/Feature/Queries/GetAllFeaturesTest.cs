using Application.IntegrationTests.Common;
using Application.UseCases.Feature.Queries.GetAllFeatures;
using Domain.Core.Feature;
using Domain.Core.Game;
using FluentAssertions;

namespace Application.IntegrationTests.UseCases.Feature.Queries
{
    public class GetAllFeaturesTest(IntegrationTestWebAppFactory factory) : BaseIntegrationTest(factory)
    {
        [Fact]
        public async Task GetAllFeatures_Should_Features()
        {
            #region Arrange
            var gameMock = new GameEntity { Name = "Animals", Description = "Desc" };
            DbContext.Games.Add(gameMock);
            await DbContext.SaveChangesAsync();
            var featureMock = new FeatureEntity { GameId = gameMock.Id, Name = "Lion" };
            DbContext.Features.Add(featureMock);
            await DbContext.SaveChangesAsync();
            var request = new GetAllFeaturesRequest();
            #endregion

            #region Action
            var response = await Sender.Send(request);
            #endregion

            #region Assert
            response.Should().NotBeNull();
            response.Should().ContainSingle();
            #endregion
        }
    }
}
