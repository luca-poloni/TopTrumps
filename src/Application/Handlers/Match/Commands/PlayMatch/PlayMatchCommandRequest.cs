using MediatR;

namespace Application.Handlers.Match.Commands.PlayMatch
{
    public record PlayMatchCommandRequest : IRequest<PlayMatchCommandResponse>
    {
        public uint Id { get; init; }
    }
}
