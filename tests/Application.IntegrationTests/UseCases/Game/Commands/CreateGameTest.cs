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
            response.Name.Should().Be("Animals");
            response.Description.Should().Be("All animals of the world.");
            #endregion
        }

        [Fact]
        public async Task CreateGame_With_EmptyName_Should_ThrowArgumentException()
        {
            #region Arrange
            var request = new CreateGameRequest { Name = string.Empty, Description = "All animals of the world." };
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
        public async Task CreateGame_With_EmptyDescription_Should_ThrowArgumentException()
        {
            #region Arrange
            var request = new CreateGameRequest { Name = "Animals", Description = string.Empty };
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
