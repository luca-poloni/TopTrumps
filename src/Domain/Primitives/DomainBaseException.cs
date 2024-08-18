namespace Domain.Primitives
{
    public abstract class DomainBaseException(string defaultMessage) : Exception(defaultMessage) { }
}
