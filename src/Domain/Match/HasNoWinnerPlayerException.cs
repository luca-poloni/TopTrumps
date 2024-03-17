using Domain.Core;

namespace Domain.Match
{
    public class HasNoWinnerPlayerException : DomainBaseException
    {
        public HasNoWinnerPlayerException() : base("Has no winner player.") { }
    }
}
