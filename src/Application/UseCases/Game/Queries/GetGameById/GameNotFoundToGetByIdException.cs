using Application.Common.Exceptions;

namespace Application.UseCases.Game.Queries.GetGameById
{
    public class GameNotFoundToGetByIdException() : ApplicationBaseException("Game not found to get by id.") { }
}
