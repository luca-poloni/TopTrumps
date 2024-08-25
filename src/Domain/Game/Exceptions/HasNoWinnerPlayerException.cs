using Domain.Common.Primitives;

namespace Domain.Game.Exceptions
{
    public class HasNoWinnerPlayerException() : DomainBaseException("Has no winner player.") { }
}
