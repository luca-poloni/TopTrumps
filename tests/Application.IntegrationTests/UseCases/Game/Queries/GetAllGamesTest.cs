using Application.IntegrationTests.Common;
using Application.UseCases.Game.Queries.GetAllGames;
using Domain.Core.Game;
using FluentAssertions;

namespace Application.IntegrationTests.UseCases.Game.Queries
{
    public class GetAllGamesTest(IntegrationTestWebAppFactory factory) : BaseIntegrationTest(factory)
    {
        [Fact]
        public async Task GetAllGames_Should_Games()
        {
            #region Arrange
            var game = new GameEntity() { Name = "Animals", Description = "All animals of the world." };
            DbContext.Games.Add(game);
            await DbContext.SaveChangesAsync();
            var request = new GetAllGamesRequest();
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
