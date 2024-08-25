using Domain.Common.Primitives;

namespace Domain.Game.Exceptions
{
    public class PowerByIdNotFoundException() : DomainBaseException("Power by id not found.") { }
}
