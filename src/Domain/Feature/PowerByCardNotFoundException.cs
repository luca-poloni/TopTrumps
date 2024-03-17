using Domain.Core;

namespace Domain.Feature
{
    public class PowerByCardNotFoundException : DomainBaseException
    {
        public PowerByCardNotFoundException() : base("Power by card not found.") { }
    }
}
