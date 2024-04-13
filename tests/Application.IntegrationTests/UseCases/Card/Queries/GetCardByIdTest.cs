using Application.IntegrationTests.Common;
using Application.UseCases.Card.Queries.GetCardById;
using Domain.Core.Card;
using Domain.Core.Game;
using FluentAssertions;

namespace Application.IntegrationTests.UseCases.Card.Queries
{
    public class GetCardByIdTest(IntegrationTestWebAppFactory factory) : BaseIntegrationTest(factory)
    {
        [Fact]
        public async Task GetCardById_With_ValidId__Should_ExistingCard()
        {
            #region Arrange
            var gameMock = new GameEntity { Name = "Animals", Description = "Desc" };
            DbContext.Games.Add(gameMock);
            await DbContext.SaveChangesAsync();
            var cardMock = new CardEntity { GameId = gameMock.Id, Name = "Lion", IsTopTrumps = true };
            DbContext.Cards.Add(cardMock);
            await DbContext.SaveChangesAsync();
            var request = new GetCardByIdRequest { Id = cardMock.Id };
            #endregion

            #region Action
            var response = await Sender.Send(request);
            #endregion

            #region Assert
            response.Id.Should().Be(cardMock.Id);
            response.GameId.Should().Be(cardMock.GameId);
            response.Name.Should().Be(cardMock.Name);
            response.IsTopTrumps.Should().Be(cardMock.IsTopTrumps);
            #endregion
        }

        [Fact]
        public async Task GetCardById_With_EmptyId_Should_ThrowArgumentException()
        {
            #region Arrange
            var request = new GetCardByIdRequest { Id = default };
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
        public async Task GetCardById_With_NoExistingId_Should_ThrowCardNotFoundToGetByIdException()
        {
            #region Arrange
            var request = new GetCardByIdRequest { Id = Guid.NewGuid() };
            #endregion

            #region Action
            var action = async () => await Sender.Send(request);
            #endregion

            #region Assert
            await action
                .Should()
                .ThrowAsync<CardNotFoundToGetByIdException>()
                .WithMessage("Card not found to get by id.");
            #endregion
        }
    }
}
