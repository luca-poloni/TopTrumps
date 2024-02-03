namespace Domain.Feature
{
    public interface IFeatureRepository
    {
        Task<FeatureEntity> GetById(uint id, CancellationToken cancellationToken);
        Task<FeatureEntity> GetAll(CancellationToken cancellationToken);
    }
}
