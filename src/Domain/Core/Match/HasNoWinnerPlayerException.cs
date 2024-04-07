using Domain.Common;

namespace Domain.Core.Match
{
    public class HasNoWinnerPlayerException() : DomainBaseException("Has no winner player.") { }
}
