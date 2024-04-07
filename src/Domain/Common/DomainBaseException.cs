namespace Domain.Common
{
    public abstract class DomainBaseException(string defaultMessage) : Exception(defaultMessage) { }
}
