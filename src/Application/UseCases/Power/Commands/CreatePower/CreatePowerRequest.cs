using MediatR;

namespace Application.UseCases.Power.Commands.CreatePower
{
    public record CreatePowerRequest : IRequest<CreatePowerResponse>
    {
        public Guid CardId { get; set; } = default;
        public Guid FeatureId { get; set; } = default;
        public uint Value { get; set; } = default;
    }
}
