using Application.IntegrationTests.Common;
using Application.UseCases.Feature.Commands.UpdateFeature;
using Domain.Core.Feature;
using Domain.Core.Game;
using FluentAssertions;

namespace Application.IntegrationTests.UseCases.Feature.Commands
{
    public class UpdateFeatureTest(IntegrationTestWebAppFactory factory) : BaseIntegrationTest(factory)
    {
        [Fact]
        public async Task UpdateFeature_WithValidInput_Should_UpdatedFeature()
        {
            #region Arrange
            var gameMock = new GameEntity { Name = "Animals", Description = "Desc" };
            DbContext.Games.Add(gameMock);
            await DbContext.SaveChangesAsync();
            var featureMock = new FeatureEntity { GameId = gameMock.Id, Name = "Height" };
            DbContext.Features.Add(featureMock);
            await DbContext.SaveChangesAsync();
            var request = new UpdateFeatureRequest { Id = featureMock.Id, Name = "Weight" };
            #endregion

            #region Action
            var response = await Sender.Send(request);
            #endregion

            #region Assert
            response.Should().NotBeNull();
            response.Id.Should().Be(featureMock.Id);
            response.GameId.Should().Be(featureMock.GameId);
            response.Name.Should().Be("Weight");
            #endregion
        }

        [Fact]
        public async Task UpdateFeature_With_EmptyId_Should_ThrowArgumentException()
        {
            #region Arrange
            var request = new UpdateFeatureRequest { Id = Guid.Empty, Name = "Weight" };
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
        public async Task UpdateFeature_With_NoExistingId_Should_ThrowFeatureNotFoundToUpdateException()
        {
            #region Arrange
            var request = new UpdateFeatureRequest { Id = Guid.NewGuid(), Name = "Weight" };
            #endregion

            #region Action
            var action = async () => await Sender.Send(request);
            #endregion

            #region Assert
            await action
                .Should()
                .ThrowAsync<FeatureNotFoundToUpdateException>()
                .WithMessage("Feature not found to update.");
            #endregion
        }

        [Fact]
        public async Task UpdateFeature_With_EmptyName_Should_ThrowArgumentException()
        {
            #region Arrange
            var request = new UpdateFeatureRequest { Id = Guid.NewGuid(), Name = string.Empty };
            #endregion

            #region Action
            var action = async () => await Sender.Send(request);
            #endregion

            #region Assert
            await action
                .Should()
                .ThrowAsync<ArgumentException>()
                .WithMessage("The name can't be empty.");
            #endregion
        }
    }
}