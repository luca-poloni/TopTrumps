using Domain.Core;

namespace Domain.Card
{
    public class PowerByFeatureNotFoundException : DomainBaseException
    {
        public PowerByFeatureNotFoundException() : base("Power by feature not found.") { }
    }
}
