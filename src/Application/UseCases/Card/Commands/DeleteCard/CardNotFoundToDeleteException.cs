using Application.Common.Exceptions;

namespace Application.UseCases.Card.Commands.DeleteCard
{
    public class CardNotFoundToDeleteException() : ApplicationBaseException("Card not found to delete.") { }
}
