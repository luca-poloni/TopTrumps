namespace Domain.Common
{
    public abstract class DomainBaseException : Exception
    {
        protected DomainBaseException(string defaultMessage) : base(defaultMessage) { }
    }
}
