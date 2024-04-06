using Application.IntegrationTests.Common;
using Application.UseCases.Card.Commands.CreateCard;
using Domain.Core.Game;
using FluentAssertions;

namespace Application.IntegrationTests.UseCases.Card.Commands
{
    public class CreateCardTest(IntegrationTestWebAppFactory factory) : BaseIntegrationTest(factory)
    {
        [Fact]
        public async Task CreateCard_With_ValidInput_Should_NewCardToDatabase()
        {
            #region Arrange
            var gameMock = new GameEntity { Name = "Animals", Description = "Desc" };
            DbContext.Games.Add(gameMock);
            await DbContext.SaveChangesAsync();
            var request = new CreateCardRequest { GameId = gameMock.Id, Name = "Lion" };
            #endregion

            #region Action
            var response = await Sender.Send(request);
            #endregion

            #region Assert
            response.Should().NotBeNull();
            response.Id.Should().NotBeEmpty();
            response.GameId.Should().Be(gameMock.Id);
            response.Name.Should().Be(request.Name);
            response.IsTopTrumps.Should().Be(request.IsTopTrumps);
            #endregion
        }

        [Fact]
        public async Task CreateCard_With_EmptyGameId_Should_ThrowArgumentException()
        {
            #region Arrange
            var request = new CreateCardRequest { GameId = default, Name = "Lion" };
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
        public async Task CreateCard_With_EmptyName_Should_ThrowArgumentException()
        {
            #region Arrange
            var request = new CreateCardRequest { GameId = Guid.NewGuid(), Name = string.Empty };
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
