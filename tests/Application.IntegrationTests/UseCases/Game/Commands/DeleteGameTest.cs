using Application.IntegrationTests.Common;
using Application.UseCases.Game.Commands.DeleteGame;
using Domain.Core.Game;
using FluentAssertions;

namespace Application.IntegrationTests.UseCases.Game.Commands
{
    public class DeleteGameTest(IntegrationTestWebAppFactory factory) : BaseIntegrationTest(factory)
    {
        [Fact]
        public async Task DeleteGame_With_ValidId_Should_DeletedGame()
        {
            #region Arrange
            var game = new GameEntity();
            DbContext.Games.Add(game);
            await DbContext.SaveChangesAsync();
            var request = new DeleteGameRequest { Id = game.Id };
            #endregion

            #region Action
            await Sender.Send(request);
            var gameDeleted = DbContext.Games.SingleOrDefault(game => game.Id == game.Id);
            #endregion

            #region Assert
            gameDeleted.Should().BeNull();
            #endregion
        }

        [Fact]
        public async Task DeleteGame_With_EmptyId_Should_ThrowArgumentException()
        {
            #region Arrange
            var request = new DeleteGameRequest();
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
        public async Task UpdateGame_With_NoExistingId_Should_ThrowArgumentException()
        {
            #region Arrange
            var request = new DeleteGameRequest { Id = Guid.NewGuid() };
            #endregion

            #region Action
            var action = async () => await Sender.Send(request);
            #endregion

            #region Assert
            await action
                .Should()
                .ThrowAsync<ArgumentException>()
                .WithMessage("Game not found to delete.");
            #endregion
        }
    }
}
