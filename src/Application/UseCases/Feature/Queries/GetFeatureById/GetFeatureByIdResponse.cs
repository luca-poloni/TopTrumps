namespace Application.UseCases.Feature.Queries.GetFeatureById
{
    public record GetFeatureByIdResponse
    {
        public Guid Id { get; set; } = default;
        public Guid GameId { get; set; } = default;
        public string Name { get; set; } = null!;
    }
}
