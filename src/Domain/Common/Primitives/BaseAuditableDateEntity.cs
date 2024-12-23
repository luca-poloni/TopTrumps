using Ardalis.SharedKernel;

namespace Domain.Common.Primitives
{
    public abstract class BaseAuditableDateEntity : EntityBase<Guid>
    {
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset LastModified { get; set; }
        public DateTimeOffset? Deleted { get; set; }
    }
}
