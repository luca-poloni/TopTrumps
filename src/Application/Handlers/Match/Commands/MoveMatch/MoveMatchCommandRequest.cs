using MediatR;

namespace Application.Handlers.Match.Commands.MoveMatch
{
    public record MoveMatchCommandRequest : IRequest<MoveMatchCommandResponse>
    {
        public uint Id { get; init; }
        public string FeatureName { get; init; } = null!;
    }
}
