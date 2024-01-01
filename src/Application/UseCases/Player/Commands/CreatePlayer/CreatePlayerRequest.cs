using MediatR;

namespace Application.UseCases.Player.Commands
{
    public record CreatePlayerRequest : IRequest<CreatePlayerResponse>
    {
        public uint MatchId { get; init; }
        public string Name { get; init; } = string.Empty;
    }
}
