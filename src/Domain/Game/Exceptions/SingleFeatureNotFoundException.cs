using Domain.Common.Primitives;

namespace Domain.Game.Exceptions
{
    public class SingleFeatureNotFoundException() : DomainBaseException("Single feature not found.") { }
}
