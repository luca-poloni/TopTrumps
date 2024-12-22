using Domain.Common.Primitives;

namespace Domain.Game.Exceptions
{
    public sealed class SinglePlayerCardNotFoundException() : DomainBaseException("Single player card not found.") { }
}
