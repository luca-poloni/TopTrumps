using MediatR;

namespace Application.UseCases.Power.Commands.UpdatePower
{
    public record UpdatePowerRequest : IRequest<UpdatePowerResponse>
    {
        public Guid Id { get; set; } = default;
        public uint Value { get; set; } = default;
    }
}
