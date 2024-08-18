using Domain.Primitives;

namespace Domain.Game.Exceptions
{
    public class PowerByCardNotFoundException() : DomainBaseException("Power by card not found.") { }
}
