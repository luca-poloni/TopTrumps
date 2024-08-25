using Domain.Common.Primitives;

namespace Domain.Game.Exceptions
{
    public class SinglePowerNotFoundException() : DomainBaseException("Single power not found.") { }
}
