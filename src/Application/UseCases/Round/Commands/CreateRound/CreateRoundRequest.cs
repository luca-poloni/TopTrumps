using MediatR;

namespace Application.UseCases.Round.Commands
{
    public record CreateRoundRequest : IRequest<CreateRoundResponse>
    {
        public uint MatchId { get; init; }
    }
}
