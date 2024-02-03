namespace Domain.Power
{
    public interface IPowerRepository
    {
        Task<PowerEntity> GetById(uint id, CancellationToken cancellationToken);
        Task<PowerEntity> GetAll(CancellationToken cancellationToken);
    }
}
