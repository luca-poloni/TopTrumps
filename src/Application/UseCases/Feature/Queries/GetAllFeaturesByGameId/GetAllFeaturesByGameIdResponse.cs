namespace Application.UseCases.Feature.Queries.GetAllFeaturesByGameId
{
    public record GetAllFeaturesByGameIdResponse
    {
        public Guid Id { get; set; } = default;
        public Guid GameId { get; set; } = default;
        public string Name { get; set; } = null!;
    }
}
