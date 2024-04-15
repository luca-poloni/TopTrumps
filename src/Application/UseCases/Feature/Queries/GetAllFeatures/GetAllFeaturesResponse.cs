namespace Application.UseCases.Feature.Queries.GetAllFeatures
{
    public record GetAllFeaturesResponse
    {
        public Guid Id { get; set; } = default;
        public Guid GameId { get; set; } = default;
        public string Name { get; set; } = null!;
    }
}
