using Application.Common.Exceptions;

namespace Application.UseCases.Game.Commands.UpdateGame
{
    public class GameNotFoundToUpdateException() : ApplicationBaseException("Game not found to update.") { }
}
