using Domain.Common;

namespace Domain.Core.Match
{
    public class HasNoMoreCardsToGiveException() : DomainBaseException("Has no more cards to give.") { }
}
