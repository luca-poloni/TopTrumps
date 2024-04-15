using Application.IntegrationTests.Common;
using Application.UseCases.Feature.Queries.GetFeatureById;
using Domain.Core.Feature;
using Domain.Core.Game;
using FluentAssertions;

namespace Application.IntegrationTests.UseCases.Feature.Queries
{
    public class GetFeatureByIdTest(IntegrationTestWebAppFactory factory) : BaseIntegrationTest(factory)
    {
        [Fact]
        public async Task GetFeatureById_With_ValidId__Should_ExistingFeature()
        {
            #region Arrange
            var gameMock = new GameEntity { Name = "Animals", Description = "Desc" };
            DbContext.Games.Add(gameMock);
            await DbContext.SaveChangesAsync();
            var featureMock = new FeatureEntity { GameId = gameMock.Id, Name = "Weight" };
            DbContext.Features.Add(featureMock);
            await DbContext.SaveChangesAsync();
            var request = new GetFeatureByIdRequest { Id = featureMock.Id };
            #endregion

            #region Action
            var response = await Sender.Send(request);
            #endregion

            #region Assert
            response.Id.Should().Be(featureMock.Id);
            response.GameId.Should().Be(featureMock.GameId);
            response.Name.Should().Be(featureMock.Name);
            #endregion
        }

        [Fact]
        public async Task GetFeatureById_With_EmptyId_Should_ThrowArgumentException()
        {
            #region Arrange
            var request = new GetFeatureByIdRequest { Id = default };
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
        public async Task GetFeatureById_With_NoExistingId_Should_ThrowFeatureNotFoundToGetByIdException()
        {
            #region Arrange
            var request = new GetFeatureByIdRequest { Id = Guid.NewGuid() };
            #endregion

            #region Action
            var action = async () => await Sender.Send(request);
            #endregion

            #region Assert
            await action
                .Should()
                .ThrowAsync<FeatureNotFoundToGetByIdException>()
                .WithMessage("Feature not found to get by id.");
            #endregion
        }
    }
}
