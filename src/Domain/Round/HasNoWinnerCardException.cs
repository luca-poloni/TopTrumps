using Domain.Core;

namespace Domain.Round
{
    public class HasNoWinnerCardException : DomainBaseException
    {
        public HasNoWinnerCardException() : base("Has no winner card.") { }
    }
}
