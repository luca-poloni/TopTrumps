namespace Domain.Core.Feature
{
    public interface IFeatureRepository
    {
        void Add(FeatureEntity feature);
        void Update(FeatureEntity feature);
        void Delete(FeatureEntity feature);
        Task<FeatureEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<FeatureEntity?> GetByIdAsNoTrackingAsync(Guid id, CancellationToken cancellationToken);
        Task<IEnumerable<FeatureEntity>> GetAllAsNoTrackingAsync(CancellationToken cancellationToken);
    }
}
