using Application.IntegrationTests.Common;
using Application.UseCases.Card.Commands.DeleteCard;
using Domain.Core.Card;
using Domain.Core.Game;
using FluentAssertions;

namespace Application.IntegrationTests.UseCases.Card.Commands
{
    public class DeleteCardTest(IntegrationTestWebAppFactory factory) : BaseIntegrationTest(factory)
    {
        [Fact]
        public async Task DeleteCard_With_ValidId_Should_DeletedCard()
        {
            #region Arrange
            var gameMock = new GameEntity { Name = "Animals", Description = "Desc" };
            DbContext.Games.Add(gameMock);
            await DbContext.SaveChangesAsync();
            var cardMock = new CardEntity { GameId = gameMock.Id, Name = "Lion", IsTopTrumps = true };
            DbContext.Cards.Add(cardMock);
            await DbContext.SaveChangesAsync();
            var request = new DeleteCardRequest { Id = cardMock.Id };
            #endregion

            #region Action
            await Sender.Send(request);
            var cardDeleted = DbContext.Cards.SingleOrDefault(card => card.Id == card.Id);
            #endregion

            #region Assert
            cardDeleted.Should().BeNull();
            #endregion
        }

        [Fact]
        public async Task DeleteCard_With_EmptyId_Should_ThrowArgumentException()
        {
            #region Arrange
            var request = new DeleteCardRequest();
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
        public async Task DeleteCard_With_NoExistingId_Should_ThrowCardNotFoundToDeleteException()
        {
            #region Arrange
            var request = new DeleteCardRequest { Id = Guid.NewGuid() };
            #endregion

            #region Action
            var action = async () => await Sender.Send(request);
            #endregion

            #region Assert
            await action
                .Should()
                .ThrowAsync<CardNotFoundToDeleteException>()
                .WithMessage("Card not found to delete.");
            #endregion
        }
    }
}
