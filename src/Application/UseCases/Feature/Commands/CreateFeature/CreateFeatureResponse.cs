namespace Application.UseCases.Feature.Commands.CreateFeature
{
    public record CreateFeatureResponse
    {
        public Guid Id { get; set; } = default;
        public Guid GameId { get; set; } = default;
        public string Name { get; set; } = null!;
    }
}
