namespace Domain.Common.Primitives
{
    public abstract class DomainBaseException(string defaultMessage) : Exception(defaultMessage) { }
}
