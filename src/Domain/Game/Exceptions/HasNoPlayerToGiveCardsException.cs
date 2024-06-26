using Domain.Common;

namespace Domain.Game.Exceptions
{
    public class HasNoPlayerToGiveCardsException() : DomainBaseException("Has no player to give cards.") { }
}
