using Application.Common.Exceptions;

namespace Application.UseCases.Card.Queries.GetCardById
{
    public class CardNotFoundToGetByIdException() : ApplicationBaseException("Card not found to get by id.") { }
}
