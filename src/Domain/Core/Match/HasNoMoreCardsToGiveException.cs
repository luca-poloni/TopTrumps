using Domain.Common;

namespace Domain.Core.Match
{
    public class HasNoMoreCardsToGiveException : DomainBaseException
    {
        public HasNoMoreCardsToGiveException() : base("Has no more cards to give.") { }
    }
}
