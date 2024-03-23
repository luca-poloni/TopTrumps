using Application.IntegrationTests.Core;
using Application.UseCases.Game.Commands.CreateGame;
using FluentAssertions;

namespace Application.IntegrationTests.UseCases.Game.Commands
{
    public class CreateGameTests(IntegrationTestWebAppFactory factory) : BaseIntegrationTest(factory)
    {
        [Fact]
        public async Task CreateGame_With_ValidParameters_Should_NewGameToDatabase()
        {
            #region Arrange
            var request = new CreateGameRequest { Name = "Animals", Description = "All animals of the world." };
            #endregion

            #region Action
            var response = await Sender.Send(request);
            #endregion

            #region Assert
            response.Should().NotBeNull();
            response.Id.Should().NotBeEmpty();
            response.Name.Should().NotBeNullOrEmpty();
            response.Description.Should().NotBeNullOrEmpty();
            #endregion
        }

        [Fact]
        public async Task CreateGame_With_InvalidName_Should_ThrowArgumentException()
        {
            #region Arrange
            var request = new CreateGameRequest { Name = string.Empty, Description = "All animals of the world." };
            #endregion

            #region Action
            var action = async () => { await Sender.Send(request); };
            #endregion

            #region Assert
            await action.Should().ThrowAsync<ArgumentException>();
            #endregion
        }

        [Fact]
        public async Task CreateGame_With_InvalidDescription_Should_ThrowArgumentException()
        {
            #region Arrange
            var request = new CreateGameRequest { Name = "Animals", Description = string.Empty };
            #endregion

            #region Action
            var action = async () => { await Sender.Send(request); };
            #endregion

            #region Assert
            await action.Should().ThrowAsync<ArgumentException>();
            #endregion
        }
    }
}
