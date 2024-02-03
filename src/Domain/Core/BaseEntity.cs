namespace Domain.Core
{
    public abstract class BaseEntity<T> where T : IComparable
    {
        public T? Id { get; protected set; }
    }
}
