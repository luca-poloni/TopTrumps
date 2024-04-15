using Application.IntegrationTests.Common;
using Application.UseCases.Feature.Commands.CreateFeature;
using Domain.Core.Game;
using FluentAssertions;

namespace Application.IntegrationTests.UseCases.Feature.Commands
{
    public class CreateFeatureTest(IntegrationTestWebAppFactory factory) : BaseIntegrationTest(factory)
    {
        [Fact]
        public async Task CreateFeature_With_ValidInput_Should_NewFeatureToDatabase()
        {
            #region Arrange
            var gameMock = new GameEntity { Name = "Animals", Description = "Desc" };
            DbContext.Games.Add(gameMock);
            await DbContext.SaveChangesAsync();
            var request = new CreateFeatureRequest { GameId = gameMock.Id, Name = "Height" };
            #endregion

            #region Action
            var response = await Sender.Send(request);
            #endregion

            #region Assert
            response.Should().NotBeNull();
            response.Id.Should().NotBeEmpty();
            response.GameId.Should().Be(gameMock.Id);
            response.Name.Should().Be(request.Name);
            #endregion
        }

        [Fact]
        public async Task CreateFeature_With_EmptyFeatureId_Should_ThrowArgumentException()
        {
            #region Arrange
            var request = new CreateFeatureRequest { GameId = default, Name = "Height" };
            #endregion

            #region Action
            var action = async () => await Sender.Send(request);
            #endregion

            #region Assert
            await action
                .Should()
                .ThrowAsync<ArgumentException>()
                .WithMessage("The game id can't be empty.");
            #endregion
        }

        [Fact]
        public async Task CreateFeature_With_EmptyName_Should_ThrowArgumentException()
        {
            #region Arrange
            var request = new CreateFeatureRequest { GameId = Guid.NewGuid(), Name = string.Empty };
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
