namespace Application.UseCases.Power.Queries.GetPowerByCardId
{
    public record GetPowerByIdResponse
    {
        public Guid Id { get; set; } = default;
        public Guid CardId { get; set; } = default;
        public Guid FeatureId { get; set; } = default;
        public uint Value { get; set; } = default;
    }
}
