namespace Domain.Common.Primitives
{
    public abstract class BaseAuditableEntity : BaseAuditableDateEntity
    {
        public string? CreatedBy { get; set; }
        public string? LastModifiedBy { get; set; }
        public string? DeletedBy { get; set; }
    }
}
