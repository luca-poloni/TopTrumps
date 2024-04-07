using Application.Common.Exceptions;

namespace Application.UseCases.Game.Commands.DeleteGame
{
    public class GameNotFoundToDeleteException() : ApplicationBaseException("Game not found to delete.") { }
}
