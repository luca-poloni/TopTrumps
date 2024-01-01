using Application.IntegrationTests.Common;
using Application.UseCases.Match.Commands;
using Domain.Entities;
using FluentAssertions;

namespace Application.IntegrationTests.UseCases.Match.Commands
{
    public class CreateMatchTests(IntegrationTestWebAppFactory factory) : BaseIntegrationTest(factory)
    {
        [Fact]
        public async Task CreateMatch_With_ValidParameters_Should_ValidMatchResponse()
        {
            #region Arrange
            var game = new GameEntity("Animals", "Animals of the world.");
            DbContext.Games.Add(game);
            DbContext.SaveChanges();
            var request = new CreateMatchRequest { GameId = game.Id };
            #endregion

            #region Action
            var response = await Sender.Send(request);
            #endregion

            #region Assert
            response.Should().NotBeNull();
            response.Id.Should().NotBe(0);
            response.GameId.Should().NotBe(0);
            response.IsFinish.Should().BeFalse();
            #endregion
        }

        [Fact]
        public async Task CreateMatch_With_InvalidGameId_Should_ThrowArgumentException()
        {
            #region Arrange
            var request = new CreateMatchRequest { GameId = 0 };
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
