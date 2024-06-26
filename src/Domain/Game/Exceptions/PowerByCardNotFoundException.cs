using Domain.Common;

namespace Domain.Game.Exceptions
{
    public class PowerByCardNotFoundException() : DomainBaseException("Power by card not found.") { }
}
