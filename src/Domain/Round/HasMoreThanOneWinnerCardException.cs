using Domain.Core;

namespace Domain.Round
{
    public class HasMoreThanOneWinnerCardException : DomainBaseException
    {
        public HasMoreThanOneWinnerCardException() : base("Has more than one winner card.") { }
    }
}
