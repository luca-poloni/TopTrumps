using MediatR;

namespace Application.Handlers.Match.Commands.PlayMatch
{
    public record PlayMatchRequest : IRequest<PlayMatchResponse>
    {
        public uint Id { get; init; }
    }
}
