using Application.IntegrationTests.Common;
using Application.UseCases.Feature.Commands.DeleteFeature;
using Domain.Core.Feature;
using Domain.Core.Game;
using FluentAssertions;

namespace Application.IntegrationTests.UseCases.Feature.Commands
{
    public class DeleteFeatureTest(IntegrationTestWebAppFactory factory) : BaseIntegrationTest(factory)
    {
        [Fact]
        public async Task DeleteFeature_With_ValidId_Should_DeletedFeature()
        {
            #region Arrange
            var gameMock = new GameEntity { Name = "Animals", Description = "Desc" };
            DbContext.Games.Add(gameMock);
            await DbContext.SaveChangesAsync();
            var featureMock = new FeatureEntity { GameId = gameMock.Id, Name = "Height" };
            DbContext.Features.Add(featureMock);
            await DbContext.SaveChangesAsync();
            var request = new DeleteFeatureRequest { Id = featureMock.Id };
            #endregion

            #region Action
            await Sender.Send(request);
            var featureDeleted = DbContext.Features.SingleOrDefault(feature => feature.Id == feature.Id);
            #endregion

            #region Assert
            featureDeleted.Should().BeNull();
            #endregion
        }

        [Fact]
        public async Task DeleteFeature_With_EmptyId_Should_ThrowArgumentException()
        {
            #region Arrange
            var request = new DeleteFeatureRequest();
            #endregion

            #region Action
            var action = async () => await Sender.Send(request);
            #endregion

            #region Assert
            await action
                .Should()
                .ThrowAsync<ArgumentException>()
                .WithMessage("The id can't be empty.");
            #endregion
        }

        [Fact]
        public async Task DeleteFeature_With_NoExistingId_Should_ThrowFeatureNotFoundToDeleteException()
        {
            #region Arrange
            var request = new DeleteFeatureRequest { Id = Guid.NewGuid() };
            #endregion

            #region Action
            var action = async () => await Sender.Send(request);
            #endregion

            #region Assert
            await action
                .Should()
                .ThrowAsync<FeatureNotFoundToDeleteException>()
                .WithMessage("Feature not found to delete.");
            #endregion
        }
    }
}
