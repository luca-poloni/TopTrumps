using Application.IntegrationTests.Common;
using Application.UseCases.Card.Commands.UpdateCard;
using Domain.Core.Card;
using Domain.Core.Game;
using FluentAssertions;

namespace Application.IntegrationTests.UseCases.Card.Commands
{
    public class UpdateCardTest(IntegrationTestWebAppFactory factory) : BaseIntegrationTest(factory)
    {
        [Fact]
        public async Task UpdateCard_WithValidInput_Should_UpdatedCard()
        {
            #region Arrange
            var gameMock = new GameEntity { Name = "Animals", Description = "Desc" };
            DbContext.Games.Add(gameMock);
            await DbContext.SaveChangesAsync();
            var cardMock = new CardEntity { GameId = gameMock.Id, Name = "Lion", IsTopTrumps = true };
            DbContext.Cards.Add(cardMock);
            await DbContext.SaveChangesAsync();
            var request = new UpdateCardRequest { Id = cardMock.Id, Name = "Cat", IsTopTrumps = false };
            #endregion

            #region Action
            var response = await Sender.Send(request);
            #endregion

            #region Assert
            response.Should().NotBeNull();
            response.Id.Should().Be(cardMock.Id);
            response.GameId.Should().Be(cardMock.GameId);
            response.Name.Should().Be("Cat");
            response.IsTopTrumps.Should().Be(false);
            #endregion
        }

        [Fact]
        public async Task UpdateCard_With_EmptyId_Should_ThrowArgumentException()
        {
            #region Arrange
            var request = new UpdateCardRequest { Id = Guid.Empty, Name = "Cat", IsTopTrumps = false };
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
        public async Task UpdateCard_With_NoExistingId_Should_ThrowCardNotFoundToUpdateException()
        {
            #region Arrange
            var request = new UpdateCardRequest { Id = Guid.NewGuid(), Name = "Cat", IsTopTrumps = false };
            #endregion

            #region Action
            var action = async () => await Sender.Send(request);
            #endregion

            #region Assert
            await action
                .Should()
                .ThrowAsync<CardNotFoundToUpdateException>()
                .WithMessage("Card not found to update.");
            #endregion
        }

        [Fact]
        public async Task UpdateCard_With_EmptyName_Should_ThrowArgumentException()
        {
            #region Arrange
            var request = new UpdateCardRequest { Id = Guid.NewGuid(), Name = string.Empty, IsTopTrumps = false };
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
