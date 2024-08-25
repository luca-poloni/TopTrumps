using Domain.Common.Primitives;

namespace Domain.Game.Exceptions
{
    public class SingleCardNotFoundException() : DomainBaseException("Single card not found.") { }
}
