using Application.IntegrationTests.Common;
using Application.UseCases.Game.Queries.GetGameById;
using Domain.Core.Game;
using FluentAssertions;

namespace Application.IntegrationTests.UseCases.Game.Queries
{
    public class GetGameByIdTest(IntegrationTestWebAppFactory factory) : BaseIntegrationTest(factory)
    {
        [Fact]
        public async Task GetGameById_With_ValidId_Should_ExistingGame()
        {
            #region Arrange
            var game = new GameEntity() { Name = "Animals", Description = "All animals of the world." };
            DbContext.Games.Add(game);
            await DbContext.SaveChangesAsync();
            var request = new GetGameByIdRequest { Id = game.Id };
            #endregion

            #region Action
            var response = await Sender.Send(request);
            #endregion

            #region Assert
            response.Id.Should().Be(game.Id);
            response.Name.Should().Be(game.Name);
            response.Description.Should().Be(game.Description);
            #endregion
        }

        [Fact]
        public async Task GetGameById_With_EmptyId_Should_ThrowArgumentException()
        {
            #region Arrange
            var request = new GetGameByIdRequest { Id = default };
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
        public async Task GetGameById_With_NoExistingId_Should_ThrowGameNotFoundToGetByIdException()
        {
            #region Arrange
            var request = new GetGameByIdRequest { Id = Guid.NewGuid() };
            #endregion

            #region Action
            var action = async () => await Sender.Send(request);
            #endregion

            #region Assert
            await action
                .Should()
                .ThrowAsync<GameNotFoundToGetByIdException>()
                .WithMessage("Game not found to get by id.");
            #endregion
        }
    }
}
