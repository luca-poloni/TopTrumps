
using Application.IntegrationTests.Common;
using Application.UseCases.Game.Commands;
using FluentAssertions;

namespace Application.IntegrationTests.UseCases.Game
{
    public class GameTests(IntegrationTestWebAppFactory factory) : BaseIntegrationTest(factory)
    {
        [Fact]
        public async Task Create_Should_NewGameToDatabase()
        {
            #region Arrange
            var request = new CreateGameRequest { Name = "Animals", Description = "All animals of the world." };
            #endregion

            #region Action
            var response = await Sender.Send(request);
            #endregion

            #region Assert
            response.Should().NotBeNull();
            response.Id.Should().NotBe(0);
            response.Name.Should().NotBeNullOrEmpty();
            response.Description.Should().NotBeNullOrEmpty();
            #endregion
        }
    }
}
