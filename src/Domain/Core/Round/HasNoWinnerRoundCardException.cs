using Domain.Common;

namespace Domain.Core.Round
{
    public class HasNoWinnerRoundCardException() : DomainBaseException("Has no winner round card.") { }
}
