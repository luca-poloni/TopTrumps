using Domain.Common;

namespace Domain.Game.Exceptions
{
    public class HasNoWinnerRoundCardException() : DomainBaseException("Has no winner round card.") { }
}
