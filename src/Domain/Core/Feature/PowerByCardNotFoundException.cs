using Domain.Common;

namespace Domain.Core.Feature
{
    public class PowerByCardNotFoundException() : DomainBaseException("Power by card not found.") { }
}
