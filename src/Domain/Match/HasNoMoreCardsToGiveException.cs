using Domain.Core;

namespace Domain.Match
{
    public class HasNoMoreCardsToGiveException : DomainBaseException
    {
        public HasNoMoreCardsToGiveException() : base("Has no more cards to give.") { }
    }
}
