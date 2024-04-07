using Application.Common.Exceptions;

namespace Application.UseCases.Card.Commands.UpdateCard
{
    public class CardNotFoundToUpdateException() : ApplicationBaseException("Card not found to update.") { }
}
