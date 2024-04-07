using Application.IntegrationTests.Common;
using Application.UseCases.Game.Commands.UpdateGame;
using Domain.Core.Game;
using FluentAssertions;

namespace Application.IntegrationTests.UseCases.Game.Commands
{
    public class UpdateGameTest(IntegrationTestWebAppFactory factory) : BaseIntegrationTest(factory)
    {
        [Fact]
        public async Task UpdateGame_With_ValidParameters_Should_UpdatedGameProperties()
        {
            #region Arrange
            var game = new GameEntity();
            DbContext.Games.Add(game);
            await DbContext.SaveChangesAsync();
            var request = new UpdateGameRequest { Id = game.Id, Name = "Cars", Description = "All cars of the world." };
            #endregion

            #region Action
            var response = await Sender.Send(request);
            #endregion

            #region Assert
            response.Should().NotBeNull();
            response.Id.Should().NotBeEmpty();
            response.Name.Should().Be("Cars");
            response.Description.Should().Be("All cars of the world.");
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
        public async Task UpdateGame_With_NoExistingId_Should_GameNotFoundToUpdateException()
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
                .ThrowAsync<GameNotFoundToUpdateException>()
                .WithMessage("Game not found to update.");
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
