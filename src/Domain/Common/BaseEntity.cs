namespace Domain.Common
{
    public abstract class BaseEntity<T> where T : IComparable
    {
        public T? Id { get; protected set; }
    }
}
