using Domain.Common;

namespace Domain.Core.Round
{
    public class HasNoWinnerRoundCardException : DomainBaseException
    {
        public HasNoWinnerRoundCardException() : base("Has no winner round card.") { }
    }
}
