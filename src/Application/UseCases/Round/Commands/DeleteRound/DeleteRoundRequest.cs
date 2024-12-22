using MediatR;

namespace Application.UseCases.Round.Commands.DeleteRound
{
    public record DeleteRoundRequest : IRequest
    {
        public Guid Id { get; set; } = default;
    }
}
