using Domain.Common.Primitives;

namespace Domain.Game.Exceptions
{
    public class SingleRoundNotFoundException() : DomainBaseException("Single round not found.") { }
}
