namespace Application.UseCases.Feature.Commands
{
    public record CreateFeatureResponse
    {
        public uint Id { get; init; }
        public uint CardId { get; init; }
        public string Name { get; init; } = string.Empty;
        public uint Value { get; init; }
    }
}
