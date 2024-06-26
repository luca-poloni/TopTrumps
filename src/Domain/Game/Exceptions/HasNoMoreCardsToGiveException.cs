using Domain.Common;

namespace Domain.Game.Exceptions
{
    public class HasNoMoreCardsToGiveException() : DomainBaseException("Has no more cards to give.") { }
}
