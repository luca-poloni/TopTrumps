using MediatR;

namespace Application.UseCases.Round.Commands.CreateRound
{
    public record CreateRoundRequest : IRequest<CreateRoundResponse>
    {
        public Guid MatchId { get; set; } = default;
    }
}
