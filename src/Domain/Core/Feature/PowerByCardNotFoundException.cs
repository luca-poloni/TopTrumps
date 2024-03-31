using Domain.Common;

namespace Domain.Core.Feature
{
    public class PowerByCardNotFoundException : DomainBaseException
    {
        public PowerByCardNotFoundException() : base("Power by card not found.") { }
    }
}
