using Application.IntegrationTests.Common;
using Application.UseCases.Card.Queries.GetAllCards;
using Domain.Core.Card;
using Domain.Core.Game;
using FluentAssertions;

namespace Application.IntegrationTests.UseCases.Card.Queries
{
    public class GetAllCardsTest(IntegrationTestWebAppFactory factory) : BaseIntegrationTest(factory)
    {
        [Fact]
        public async Task GetAllCards_Should_Games()
        {
            #region Arrange
            var gameMock = new GameEntity { Name = "Animals", Description = "Desc" };
            DbContext.Games.Add(gameMock);
            await DbContext.SaveChangesAsync();
            var cardMock = new CardEntity { GameId = gameMock.Id, Name = "Lion", IsTopTrumps = true };
            DbContext.Cards.Add(cardMock);
            await DbContext.SaveChangesAsync();
            var request = new GetAllCardsRequest();
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
