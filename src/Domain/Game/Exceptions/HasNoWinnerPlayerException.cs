using Domain.Common;

namespace Domain.Game.Exceptions
{
    public class HasNoWinnerPlayerException() : DomainBaseException("Has no winner player.") { }
}
