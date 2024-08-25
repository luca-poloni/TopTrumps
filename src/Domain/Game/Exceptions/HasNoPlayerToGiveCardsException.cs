using Domain.Common.Primitives;

namespace Domain.Game.Exceptions
{
    public class HasNoPlayerToGiveCardsException() : DomainBaseException("Has no player to give cards.") { }
}
