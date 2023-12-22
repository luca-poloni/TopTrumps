using MediatR;

namespace Application.UseCases.Match.Commands.MoveMatch
{
    public record MoveMatchRequest : IRequest<MoveMatchResponse>
    {
        public uint Id { get; init; }
        public string FeatureName { get; init; } = null!;
    }
}
