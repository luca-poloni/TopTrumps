namespace Domain.Core
{
    public abstract class DomainBaseException : Exception
    {
        protected DomainBaseException(string defaultMessage) : base(defaultMessage) { }
    }
}
