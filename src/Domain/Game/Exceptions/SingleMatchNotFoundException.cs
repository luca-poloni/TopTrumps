using Domain.Common.Primitives;

namespace Domain.Game.Exceptions
{
    public sealed class SingleMatchNotFoundException() : DomainBaseException("Single match not found.") { }
}
