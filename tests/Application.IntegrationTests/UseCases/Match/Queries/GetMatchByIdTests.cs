using Application.IntegrationTests.Common;
using Application.UseCases.Match.Queries;
using Domain.Entities;
using FluentAssertions;

namespace Application.IntegrationTests.UseCases.Match.Queries
{
    public class GetMatchByIdTests(IntegrationTestWebAppFactory factory) : BaseIntegrationTest(factory)
    {
        [Fact]
        public async Task GetMatchById_With_ValidParameters_Should_ValidMatchResponse()
        {
            #region Arrange
            var match = new MatchEntity(new GameEntity("Animals", "Animals of the world."));
            DbContext.Matches.Add(match);
            DbContext.SaveChanges();
            var request = new GetMatchByIdRequest { Id = match.Id };
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
        public async Task GetMatchById_With_InvalidId_Should_ThrowArgumentException()
        {
            #region Arrange
            var request = new GetMatchByIdRequest { Id = 0 };
            #endregion

            #region Action
            var action = async () => { await Sender.Send(request); };
            #endregion

            #region Assert
            await action.Should().ThrowAsync<ArgumentException>();
            #endregion
        }

        [Fact]
        public async Task GetMatchById_With_NonexistentId_Should_ThrowArgumentException()
        {
            #region Arrange
            var request = new GetMatchByIdRequest { Id = 1 };
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
