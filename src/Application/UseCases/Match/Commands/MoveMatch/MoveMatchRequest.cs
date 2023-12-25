using MediatR;

namespace Application.UseCases.Match.Commands
{
    public record MoveMatchRequest : IRequest<MoveMatchResponse>
    {
        public uint Id { get; init; }
        public string FeatureName { get; init; } = null!;
    }
}
