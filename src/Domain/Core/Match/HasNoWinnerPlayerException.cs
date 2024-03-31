using Domain.Common;

namespace Domain.Core.Match
{
    public class HasNoWinnerPlayerException : DomainBaseException
    {
        public HasNoWinnerPlayerException() : base("Has no winner player.") { }
    }
}
