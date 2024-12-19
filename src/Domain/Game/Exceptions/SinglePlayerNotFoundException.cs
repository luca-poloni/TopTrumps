using Domain.Common.Primitives;

namespace Domain.Game.Exceptions
{
    public class SinglePlayerNotFoundException() : DomainBaseException("Single player not found.") { }
}
