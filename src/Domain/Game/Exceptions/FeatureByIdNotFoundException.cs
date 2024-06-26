using Domain.Common;

namespace Domain.Game.Exceptions
{
    public class FeatureByIdNotFoundException() : DomainBaseException("Feature by id not found.") { }
}
