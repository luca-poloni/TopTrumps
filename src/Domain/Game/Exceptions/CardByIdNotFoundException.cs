using Domain.Common.Primitives;

namespace Domain.Game.Exceptions
{
    public class CardByIdNotFoundException() : DomainBaseException("Card by id not found.") { }
}
