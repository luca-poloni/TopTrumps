using Domain.Core;

namespace Domain.Round
{
    public class HasNoWinnerRoundCardException : DomainBaseException
    {
        public HasNoWinnerRoundCardException() : base("Has no winner round card.") { }
    }
}
