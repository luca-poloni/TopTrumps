using MediatR;

namespace Application.UseCases.Power.Commands.DeletePower
{
    public record DeletePowerRequest : IRequest
    {
        public Guid Id { get; set; } = default;
    }
}
