namespace Application.UseCases.Power.Commands.CreatePower
{
    public record CreatePowerResponse
    {
        public Guid Id { get; set; } = default;
        public Guid CardId { get; set; } = default;
        public Guid FeatureId { get; set; } = default;
        public uint Value { get; set; } = default;
    }
}
