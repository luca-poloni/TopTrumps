using Application.IntegrationTests.Core;
using Application.UseCases.Game.Commands.CreateGame;
using Application.UseCases.Game.Commands.UpdateGame;
using FluentAssertions;

namespace Application.IntegrationTests.UseCases.Game.Commands
{
    public class UpdateGameTest(IntegrationTestWebAppFactory factory) : BaseIntegrationTest(factory)
    {
        [Fact]
        public async Task UpdateGame_With_ValidParameters_Should_UpdatedGameProperties()
        {
            #region Arrange
            var createRequest = new CreateGameRequest { Name = "Animals", Description = "All animals of the world." };
            var createResponse = await Sender.Send(createRequest);
            var updateRequest = new UpdateGameRequest { Id = createResponse.Id, Name = "Cars", Description = "All cars of the world." };
            #endregion

            #region Action
            var updateResponse = await Sender.Send(updateRequest);
            #endregion

            #region Assert
            updateResponse.Should().NotBeNull();
            updateResponse.Id.Should().NotBeEmpty();
            updateResponse.Name.Should().Be("Cars");
            updateResponse.Description.Should().Be("All cars of the world.");
            #endregion
        }

        [Fact]
        public async Task UpdateGame_With_EmptyId_Should_ThrowArgumentException()
        {
            #region Arrange
            var request = new UpdateGameRequest { Name = "Cars", Description = "All cars of the world." };
            #endregion

            #region Action
            var action = async () => { await Sender.Send(request); };
            #endregion

            #region Assert
            await action
                .Should()
                .ThrowAsync<ArgumentException>()
                .WithMessage("The id can't be empty.");
            #endregion
        }

        [Fact]
        public async Task UpdateGame_With_NoExistingId_Should_ThrowArgumentException()
        {
            #region Arrange
            var request = new UpdateGameRequest { Id = Guid.NewGuid(), Name = "Cars", Description = "All cars of the world." };
            #endregion

            #region Action
            var action = async () => { await Sender.Send(request); };
            #endregion

            #region Assert
            await action
                .Should()
                .ThrowAsync<ArgumentException>()
                .WithMessage("Game not found.");
            #endregion
        }

        [Fact]
        public async Task UpdateGame_With_EmptyName_Should_ThrowArgumentException()
        {
            #region Arrange
            var request = new UpdateGameRequest { Id = Guid.NewGuid(), Name = string.Empty, Description = "All animals of the world." };
            #endregion

            #region Action
            var action = async () => { await Sender.Send(request); };
            #endregion

            #region Assert
            await action
                .Should()
                .ThrowAsync<ArgumentException>()
                .WithMessage("The name can't be empty.");
            #endregion
        }

        [Fact]
        public async Task UpdateGame_With_EmptyDescription_Should_ThrowArgumentException()
        {
            #region Arrange
            var request = new UpdateGameRequest { Id = Guid.NewGuid(), Name = "Animals", Description = string.Empty };
            #endregion

            #region Action
            var action = async () => { await Sender.Send(request); };
            #endregion

            #region Assert
            await action
                .Should()
                .ThrowAsync<ArgumentException>()
                .WithMessage("The description can't be empty."); ;
            #endregion
        }
    }
}
