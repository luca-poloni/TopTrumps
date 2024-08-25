using Ardalis.SharedKernel;

namespace Domain.Common.Primitives
{
    public abstract class BaseAuditableEntity : EntityBase<Guid>
    {
        public DateTimeOffset Created { get; set; }
        public string? CreatedBy { get; set; }
        public DateTimeOffset LastModified { get; set; }
        public string? LastModifiedBy { get; set; }
    }
}
